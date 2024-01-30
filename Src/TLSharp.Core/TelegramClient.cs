// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.TelegramClient
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TeleSharp.TL;
using TeleSharp.TL.Account;
using TeleSharp.TL.Auth;
using TeleSharp.TL.Contacts;
using TeleSharp.TL.Help;
using TeleSharp.TL.Messages;
using TeleSharp.TL.Upload;
using TLSharp.Core.Auth;
using TLSharp.Core.Exceptions;
using TLSharp.Core.Network;
using TLSharp.Core.Network.Exceptions;
using TLSharp.Core.Utils;

#nullable disable
namespace TLSharp.Core
{
  public class TelegramClient : IDisposable
  {
    private MtProtoSender sender;
    private TcpTransport transport;
    private string apiHash = string.Empty;
    private int apiId = 0;
    private Session session;
    private List<TLDcOption> dcOptions;
    private TcpClientConnectionHandler handler;
    private DataCenterIPVersion dcIpVersion;

    public Session Session => this.session;

    public TelegramClient(
      int apiId,
      string apiHash,
      ISessionStore store = null,
      string sessionUserId = "session",
      TcpClientConnectionHandler handler = null,
      DataCenterIPVersion dcIpVersion = DataCenterIPVersion.Default)
    {
      if (apiId == 0)
        throw new MissingApiConfigurationException("API_ID");
      if (string.IsNullOrEmpty(apiHash))
        throw new MissingApiConfigurationException("API_HASH");
      if (store == null)
        store = (ISessionStore) new FileSessionStore();
      this.apiHash = apiHash;
      this.apiId = apiId;
      this.handler = handler;
      this.dcIpVersion = dcIpVersion;
      this.session = Session.TryLoadOrCreateNew(store, sessionUserId);
      this.transport = new TcpTransport(this.session.DataCenter.Address, this.session.DataCenter.Port, this.handler);
    }

    public async Task ConnectAsync(bool reconnect = false, CancellationToken token = default (CancellationToken))
    {
      token.ThrowIfCancellationRequested();
      if (this.session.AuthKey == null | reconnect)
      {
        Step3_Response result = await Authenticator.DoAuthentication(this.transport, token).ConfigureAwait(false);
        this.session.AuthKey = result.AuthKey;
        this.session.TimeOffset = result.TimeOffset;
        result = (Step3_Response) null;
      }
      this.sender = new MtProtoSender(this.transport, this.session);
      TLRequestGetConfig config = new TLRequestGetConfig();
      TLRequestInitConnection request = new TLRequestInitConnection()
      {
        ApiId = this.apiId,
        AppVersion = "1.0.0",
        DeviceModel = "PC",
        LangCode = "en",
        Query = (TLObject) config,
        SystemVersion = "Win 10.0"
      };
      TLRequestInvokeWithLayer invokewithLayer = new TLRequestInvokeWithLayer()
      {
        Layer = 66,
        Query = (TLObject) request
      };
      await this.sender.Send((TLMethod) invokewithLayer, token).ConfigureAwait(false);
      byte[] numArray = await this.sender.Receive((TLMethod) invokewithLayer, token).ConfigureAwait(false);
      this.dcOptions = ((TLConfig) invokewithLayer.Response).DcOptions.ToList<TLDcOption>();
    }

    private async Task ReconnectToDcAsync(int dcId, CancellationToken token = default (CancellationToken))
    {
      token.ThrowIfCancellationRequested();
      if (this.dcOptions == null || !this.dcOptions.Any<TLDcOption>())
        throw new InvalidOperationException("Can't reconnect. Establish initial connection first.");
      TLExportedAuthorization exported = (TLExportedAuthorization) null;
      if (this.session.TLUser != null)
      {
        TLRequestExportAuthorization exportAuthorization = new TLRequestExportAuthorization()
        {
          DcId = dcId
        };
        exported = await this.SendRequestAsync<TLExportedAuthorization>((TLMethod) exportAuthorization, token).ConfigureAwait(false);
        exportAuthorization = (TLRequestExportAuthorization) null;
      }
      IEnumerable<TLDcOption> dcs = this.dcIpVersion != DataCenterIPVersion.OnlyIPv6 ? (this.dcIpVersion != DataCenterIPVersion.OnlyIPv4 ? this.dcOptions.Where<TLDcOption>((Func<TLDcOption, bool>) (d => d.Id == dcId)) : this.dcOptions.Where<TLDcOption>((Func<TLDcOption, bool>) (d => d.Id == dcId && !d.Ipv6))) : this.dcOptions.Where<TLDcOption>((Func<TLDcOption, bool>) (d => d.Id == dcId && d.Ipv6));
      dcs = dcs.Where<TLDcOption>((Func<TLDcOption, bool>) (d => !d.MediaOnly));
      TLDcOption dc;
      if (this.dcIpVersion != 0)
      {
        if (!dcs.Any<TLDcOption>())
          throw new Exception("Telegram server didn't provide us with any IPAddress that matches your preferences. If you chose OnlyIPvX, try switch to PreferIPvX instead.");
        dcs = (IEnumerable<TLDcOption>) dcs.OrderBy<TLDcOption, bool>((Func<TLDcOption, bool>) (d => d.Ipv6));
        dc = this.dcIpVersion == DataCenterIPVersion.PreferIPv4 ? dcs.First<TLDcOption>() : dcs.Last<TLDcOption>();
      }
      else
        dc = dcs.First<TLDcOption>();
      DataCenter dataCenter = new DataCenter(new int?(dcId), dc.IpAddress, dc.Port);
      this.transport = new TcpTransport(dc.IpAddress, dc.Port, this.handler);
      this.session.DataCenter = dataCenter;
      await this.ConnectAsync(true, token).ConfigureAwait(false);
      if (this.session.TLUser == null)
        return;
      TLRequestImportAuthorization importAuthorization = new TLRequestImportAuthorization()
      {
        Id = exported.Id,
        Bytes = exported.Bytes
      };
      TeleSharp.TL.Auth.TLAuthorization imported = await this.SendRequestAsync<TeleSharp.TL.Auth.TLAuthorization>((TLMethod) importAuthorization, token).ConfigureAwait(false);
      this.OnUserAuthenticated((TLUser) imported.User);
      importAuthorization = (TLRequestImportAuthorization) null;
      imported = (TeleSharp.TL.Auth.TLAuthorization) null;
    }

    private async Task RequestWithDcMigration(TLMethod request, CancellationToken token = default (CancellationToken))
    {
      if (this.sender == null)
        throw new InvalidOperationException("Not connected!");
      bool completed = false;
      while (!completed)
      {
        try
        {
          await this.sender.Send(request, token).ConfigureAwait(false);
          byte[] numArray = await this.sender.Receive(request, token).ConfigureAwait(false);
          completed = true;
        }
        catch (DataCenterMigrationException ex)
        {
          if (this.session.DataCenter.DataCenterId.HasValue && this.session.DataCenter.DataCenterId.Value == ex.DC)
            throw new Exception(string.Format("Telegram server replied requesting a migration to DataCenter {0} when this connection was already using this DataCenter", (object) ex.DC), (Exception) ex);
          await this.ReconnectToDcAsync(ex.DC, token).ConfigureAwait(false);
          request.ConfirmReceived = false;
        }
      }
    }

    public bool IsUserAuthorized() => this.session.TLUser != null;

    public async Task<bool> IsPhoneRegisteredAsync(string phoneNumber, CancellationToken token = default (CancellationToken))
    {
      TLRequestCheckPhone authCheckPhoneRequest = !string.IsNullOrWhiteSpace(phoneNumber) ? new TLRequestCheckPhone()
      {
        PhoneNumber = phoneNumber
      } : throw new ArgumentNullException(nameof (phoneNumber));
      await this.RequestWithDcMigration((TLMethod) authCheckPhoneRequest, token).ConfigureAwait(false);
      return authCheckPhoneRequest.Response.PhoneRegistered;
    }

    public async Task<string> SendCodeRequestAsync(string phoneNumber, CancellationToken token = default (CancellationToken))
    {
      if (string.IsNullOrWhiteSpace(phoneNumber))
        throw new ArgumentNullException(nameof (phoneNumber));
      TLRequestSendCode request = new TLRequestSendCode()
      {
        PhoneNumber = phoneNumber,
        ApiId = this.apiId,
        ApiHash = this.apiHash
      };
      await this.RequestWithDcMigration((TLMethod) request, token).ConfigureAwait(false);
      return request.Response.PhoneCodeHash;
    }

    public async Task<TLUser> MakeAuthAsync(
      string phoneNumber,
      string phoneCodeHash,
      string code,
      CancellationToken token = default (CancellationToken))
    {
      if (string.IsNullOrWhiteSpace(phoneNumber))
        throw new ArgumentNullException(nameof (phoneNumber));
      if (string.IsNullOrWhiteSpace(phoneCodeHash))
        throw new ArgumentNullException(nameof (phoneCodeHash));
      if (string.IsNullOrWhiteSpace(code))
        throw new ArgumentNullException(nameof (code));
      TLRequestSignIn request = new TLRequestSignIn()
      {
        PhoneNumber = phoneNumber,
        PhoneCodeHash = phoneCodeHash,
        PhoneCode = code
      };
      await this.RequestWithDcMigration((TLMethod) request, token).ConfigureAwait(false);
      this.OnUserAuthenticated((TLUser) request.Response.User);
      return (TLUser) request.Response.User;
    }

    public async Task<TLPassword> GetPasswordSetting(CancellationToken token = default (CancellationToken))
    {
      TLRequestGetPassword request = new TLRequestGetPassword();
      await this.RequestWithDcMigration((TLMethod) request, token).ConfigureAwait(false);
      return (TLPassword) request.Response;
    }

    public async Task<TLUser> MakeAuthWithPasswordAsync(
      TLPassword password,
      string password_str,
      CancellationToken token = default (CancellationToken))
    {
      token.ThrowIfCancellationRequested();
      byte[] password_Bytes = Encoding.UTF8.GetBytes(password_str);
      IEnumerable<byte> rv = ((IEnumerable<byte>) password.CurrentSalt).Concat<byte>((IEnumerable<byte>) password_Bytes).Concat<byte>((IEnumerable<byte>) password.CurrentSalt);
      SHA256Managed hashstring = new SHA256Managed();
      byte[] password_hash = hashstring.ComputeHash(rv.ToArray<byte>());
      TLRequestCheckPassword request = new TLRequestCheckPassword()
      {
        PasswordHash = password_hash
      };
      await this.RequestWithDcMigration((TLMethod) request, token).ConfigureAwait(false);
      this.OnUserAuthenticated((TLUser) request.Response.User);
      return (TLUser) request.Response.User;
    }

    public async Task<TLUser> SignUpAsync(
      string phoneNumber,
      string phoneCodeHash,
      string code,
      string firstName,
      string lastName,
      CancellationToken token = default (CancellationToken))
    {
      TLRequestSignUp request = new TLRequestSignUp()
      {
        PhoneNumber = phoneNumber,
        PhoneCode = code,
        PhoneCodeHash = phoneCodeHash,
        FirstName = firstName,
        LastName = lastName
      };
      await this.RequestWithDcMigration((TLMethod) request, token).ConfigureAwait(false);
      this.OnUserAuthenticated((TLUser) request.Response.User);
      return (TLUser) request.Response.User;
    }

    public async Task<T> SendRequestAsync<T>(TLMethod methodToExecute, CancellationToken token = default (CancellationToken))
    {
      await this.RequestWithDcMigration(methodToExecute, token).ConfigureAwait(false);
      object result = methodToExecute.GetType().GetProperty("Response").GetValue((object) methodToExecute);
      return (T) result;
    }

    internal async Task<T> SendAuthenticatedRequestAsync<T>(
      TLMethod methodToExecute,
      CancellationToken token = default (CancellationToken))
    {
      if (!this.IsUserAuthorized())
        throw new InvalidOperationException("Authorize user first!");
      T obj = await this.SendRequestAsync<T>(methodToExecute, token).ConfigureAwait(false);
      return obj;
    }

    public async Task<TLUser> UpdateUsernameAsync(string username, CancellationToken token = default (CancellationToken))
    {
      TLRequestUpdateUsername req = new TLRequestUpdateUsername()
      {
        Username = username
      };
      TLUser tlUser = await this.SendAuthenticatedRequestAsync<TLUser>((TLMethod) req, token).ConfigureAwait(false);
      return tlUser;
    }

    public async Task<bool> CheckUsernameAsync(string username, CancellationToken token = default (CancellationToken))
    {
      TLRequestCheckUsername req = new TLRequestCheckUsername()
      {
        Username = username
      };
      bool flag = await this.SendAuthenticatedRequestAsync<bool>((TLMethod) req, token).ConfigureAwait(false);
      return flag;
    }

    public async Task<TLImportedContacts> ImportContactsAsync(
      IReadOnlyList<TLInputPhoneContact> contacts,
      CancellationToken token = default (CancellationToken))
    {
      TLRequestImportContacts req = new TLRequestImportContacts()
      {
        Contacts = new TLVector<TLInputPhoneContact>((IEnumerable<TLInputPhoneContact>) contacts)
      };
      TLImportedContacts importedContacts = await this.SendAuthenticatedRequestAsync<TLImportedContacts>((TLMethod) req, token).ConfigureAwait(false);
      return importedContacts;
    }

    public async Task<bool> DeleteContactsAsync(
      IReadOnlyList<TLAbsInputUser> users,
      CancellationToken token = default (CancellationToken))
    {
      TLRequestDeleteContacts req = new TLRequestDeleteContacts()
      {
        Id = new TLVector<TLAbsInputUser>((IEnumerable<TLAbsInputUser>) users)
      };
      bool flag = await this.SendAuthenticatedRequestAsync<bool>((TLMethod) req, token).ConfigureAwait(false);
      return flag;
    }

    public async Task<TLLink> DeleteContactAsync(TLAbsInputUser user, CancellationToken token = default (CancellationToken))
    {
      TLRequestDeleteContact req = new TLRequestDeleteContact()
      {
        Id = user
      };
      TLLink tlLink = await this.SendAuthenticatedRequestAsync<TLLink>((TLMethod) req, token).ConfigureAwait(false);
      return tlLink;
    }

    public async Task<TLContacts> GetContactsAsync(CancellationToken token = default (CancellationToken))
    {
      TLRequestGetContacts req = new TLRequestGetContacts()
      {
        Hash = ""
      };
      TLContacts contactsAsync = await this.SendAuthenticatedRequestAsync<TLContacts>((TLMethod) req, token).ConfigureAwait(false);
      return contactsAsync;
    }

    public async Task<TLAbsUpdates> SendMessageAsync(
      TLAbsInputPeer peer,
      string message,
      CancellationToken token = default (CancellationToken))
    {
      TLAbsUpdates tlAbsUpdates = await this.SendAuthenticatedRequestAsync<TLAbsUpdates>((TLMethod) new TLRequestSendMessage()
      {
        Peer = peer,
        Message = message,
        RandomId = Helpers.GenerateRandomLong()
      }, token).ConfigureAwait(false);
      return tlAbsUpdates;
    }

    public async Task<bool> SendTypingAsync(TLAbsInputPeer peer, CancellationToken token = default (CancellationToken))
    {
      TLRequestSetTyping req = new TLRequestSetTyping()
      {
        Action = (TLAbsSendMessageAction) new TLSendMessageTypingAction(),
        Peer = peer
      };
      bool flag = await this.SendAuthenticatedRequestAsync<bool>((TLMethod) req, token).ConfigureAwait(false);
      return flag;
    }

    public async Task<TLAbsDialogs> GetUserDialogsAsync(
      int offsetDate = 0,
      int offsetId = 0,
      TLAbsInputPeer offsetPeer = null,
      int limit = 100,
      CancellationToken token = default (CancellationToken))
    {
      if (offsetPeer == null)
        offsetPeer = (TLAbsInputPeer) new TLInputPeerSelf();
      TLRequestGetDialogs req = new TLRequestGetDialogs()
      {
        OffsetDate = offsetDate,
        OffsetId = offsetId,
        OffsetPeer = offsetPeer,
        Limit = limit
      };
      TLAbsDialogs userDialogsAsync = await this.SendAuthenticatedRequestAsync<TLAbsDialogs>((TLMethod) req, token).ConfigureAwait(false);
      return userDialogsAsync;
    }

    public async Task<TLAbsUpdates> SendUploadedPhoto(
      TLAbsInputPeer peer,
      TLAbsInputFile file,
      string caption,
      CancellationToken token = default (CancellationToken))
    {
      TLAbsUpdates tlAbsUpdates = await this.SendAuthenticatedRequestAsync<TLAbsUpdates>((TLMethod) new TLRequestSendMedia()
      {
        RandomId = Helpers.GenerateRandomLong(),
        Background = false,
        ClearDraft = false,
        Media = (TLAbsInputMedia) new TLInputMediaUploadedPhoto()
        {
          File = file,
          Caption = caption
        },
        Peer = peer
      }, token).ConfigureAwait(false);
      return tlAbsUpdates;
    }

    public async Task<TLAbsUpdates> SendUploadedDocument(
      TLAbsInputPeer peer,
      TLAbsInputFile file,
      string caption,
      string mimeType,
      TLVector<TLAbsDocumentAttribute> attributes,
      CancellationToken token = default (CancellationToken))
    {
      TLAbsUpdates tlAbsUpdates = await this.SendAuthenticatedRequestAsync<TLAbsUpdates>((TLMethod) new TLRequestSendMedia()
      {
        RandomId = Helpers.GenerateRandomLong(),
        Background = false,
        ClearDraft = false,
        Media = (TLAbsInputMedia) new TLInputMediaUploadedDocument()
        {
          File = file,
          Caption = caption,
          MimeType = mimeType,
          Attributes = attributes
        },
        Peer = peer
      }, token).ConfigureAwait(false);
      return tlAbsUpdates;
    }

    public async Task<TLFile> GetFile(
      TLAbsInputFileLocation location,
      int filePartSize,
      int offset = 0,
      CancellationToken token = default (CancellationToken))
    {
      TLFile result = await this.SendAuthenticatedRequestAsync<TLFile>((TLMethod) new TLRequestGetFile()
      {
        Location = location,
        Limit = filePartSize,
        Offset = offset
      }, token).ConfigureAwait(false);
      return result;
    }

    public async Task SendPingAsync(CancellationToken token = default (CancellationToken))
    {
      await this.sender.SendPingAsync(token).ConfigureAwait(false);
    }

    public async Task<TLAbsMessages> GetHistoryAsync(
      TLAbsInputPeer peer,
      int offsetId = 0,
      int offsetDate = 0,
      int addOffset = 0,
      int limit = 100,
      int maxId = 0,
      int minId = 0,
      CancellationToken token = default (CancellationToken))
    {
      TLRequestGetHistory req = new TLRequestGetHistory()
      {
        Peer = peer,
        OffsetId = offsetId,
        OffsetDate = offsetDate,
        AddOffset = addOffset,
        Limit = limit,
        MaxId = maxId,
        MinId = minId
      };
      TLAbsMessages historyAsync = await this.SendAuthenticatedRequestAsync<TLAbsMessages>((TLMethod) req, token).ConfigureAwait(false);
      return historyAsync;
    }

    public async Task<TLFound> SearchUserAsync(string q, int limit = 10, CancellationToken token = default (CancellationToken))
    {
      TeleSharp.TL.Contacts.TLRequestSearch r = new TeleSharp.TL.Contacts.TLRequestSearch()
      {
        Q = q,
        Limit = limit
      };
      TLFound tlFound = await this.SendAuthenticatedRequestAsync<TLFound>((TLMethod) r, token).ConfigureAwait(false);
      return tlFound;
    }

    private void OnUserAuthenticated(TLUser TLUser)
    {
      this.session.TLUser = TLUser;
      this.session.SessionExpires = int.MaxValue;
      this.session.Save();
    }

    public bool IsConnected => this.transport != null && this.transport.IsConnected;

    public void Dispose()
    {
      if (this.transport == null)
        return;
      this.transport.Dispose();
      this.transport = (TcpTransport) null;
    }
  }
}
