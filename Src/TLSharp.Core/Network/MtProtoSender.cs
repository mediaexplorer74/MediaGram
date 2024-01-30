// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.Network.MtProtoSender
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TeleSharp.TL;
using TLSharp.Core.Exceptions;
using TLSharp.Core.MTProto;
using TLSharp.Core.MTProto.Crypto;
using TLSharp.Core.Network.Exceptions;
using TLSharp.Core.Network.Requests;
using TLSharp.Core.Utils;

#nullable disable
namespace TLSharp.Core.Network
{
  public class MtProtoSender
  {
    private readonly TcpTransport transport;
    private readonly Session session;
    public readonly List<ulong> needConfirmation = new List<ulong>();

    public MtProtoSender(TcpTransport transport, Session session)
    {
      this.transport = transport;
      this.session = session;
    }

    private int GenerateSequence(bool confirmed)
    {
      lock (this.session.Lock)
      {
        try
        {
          return confirmed ? this.session.Sequence++ * 2 + 1 : this.session.Sequence * 2;
        }
        finally
        {
          this.session.Save();
        }
      }
    }

    public async Task Send(TLMethod request, CancellationToken token = default (CancellationToken))
    {
      token.ThrowIfCancellationRequested();
      if (this.needConfirmation.Any<ulong>())
      {
        AckRequest ackRequest = new AckRequest(this.needConfirmation);
        using (MemoryStream memory = new MemoryStream())
        {
          using (BinaryWriter writer = new BinaryWriter((Stream) memory))
          {
            ackRequest.SerializeBody(writer);
            await this.Send(memory.ToArray(), (TLMethod) ackRequest, token).ConfigureAwait(false);
            this.needConfirmation.Clear();
          }
        }
        ackRequest = (AckRequest) null;
      }
      using (MemoryStream memory = new MemoryStream())
      {
        using (BinaryWriter writer = new BinaryWriter((Stream) memory))
        {
          request.SerializeBody(writer);
          await this.Send(memory.ToArray(), request, token).ConfigureAwait(false);
        }
      }
      this.session.Save();
    }

    public async Task Send(byte[] packet, TLMethod request, CancellationToken token = default (CancellationToken))
    {
      token.ThrowIfCancellationRequested();
      request.MessageId = this.session.GetNewMessageId();
      byte[] msgKey;
      byte[] ciphertext;
      using (MemoryStream plaintextPacket = this.makeMemory(32 + packet.Length))
      {
        using (BinaryWriter plaintextWriter = new BinaryWriter((Stream) plaintextPacket))
        {
          plaintextWriter.Write(this.session.Salt);
          plaintextWriter.Write(this.session.Id);
          plaintextWriter.Write(request.MessageId);
          plaintextWriter.Write(this.GenerateSequence(request.Confirmed));
          plaintextWriter.Write(packet.Length);
          plaintextWriter.Write(packet);
          msgKey = Helpers.CalcMsgKey(plaintextPacket.GetBuffer());
          ciphertext = AES.EncryptAES(Helpers.CalcKey(this.session.AuthKey.Data, msgKey, true), plaintextPacket.GetBuffer());
        }
      }
      using (MemoryStream ciphertextPacket = this.makeMemory(24 + ciphertext.Length))
      {
        using (BinaryWriter writer = new BinaryWriter((Stream) ciphertextPacket))
        {
          writer.Write(this.session.AuthKey.Id);
          writer.Write(msgKey);
          writer.Write(ciphertext);
          await this.transport.Send(ciphertextPacket.GetBuffer(), token).ConfigureAwait(false);
        }
      }
    }

    private Tuple<byte[], ulong, int> DecodeMessage(byte[] body)
    {
      ulong num1;
      int num2;
      byte[] numArray;
      using (MemoryStream input1 = new MemoryStream(body))
      {
        using (BinaryReader binaryReader1 = new BinaryReader((Stream) input1))
        {
          if (binaryReader1.BaseStream.Length < 8L)
            throw new InvalidOperationException("Can't decode packet");
          binaryReader1.ReadUInt64();
          using (MemoryStream input2 = new MemoryStream(AES.DecryptAES(Helpers.CalcKey(this.session.AuthKey.Data, binaryReader1.ReadBytes(16), false), binaryReader1.ReadBytes((int) (input1.Length - input1.Position)))))
          {
            using (BinaryReader binaryReader2 = new BinaryReader((Stream) input2))
            {
              binaryReader2.ReadUInt64();
              binaryReader2.ReadUInt64();
              num1 = binaryReader2.ReadUInt64();
              num2 = binaryReader2.ReadInt32();
              int count = binaryReader2.ReadInt32();
              numArray = binaryReader2.ReadBytes(count);
            }
          }
        }
      }
      return new Tuple<byte[], ulong, int>(numArray, num1, num2);
    }

    public async Task<byte[]> Receive(TLMethod request, CancellationToken token = default (CancellationToken))
    {
      while (!request.ConfirmReceived)
      {
        TcpMessage tcpMessage = await this.transport.Receive(token).ConfigureAwait(false);
        byte[] body = tcpMessage.Body;
        Tuple<byte[], ulong, int> result = this.DecodeMessage(body);
        tcpMessage = (TcpMessage) null;
        body = (byte[]) null;
        using (MemoryStream messageStream = new MemoryStream(result.Item1, false))
        {
          using (BinaryReader messageReader = new BinaryReader((Stream) messageStream))
            this.processMessage(result.Item2, result.Item3, messageReader, request, token);
        }
        token.ThrowIfCancellationRequested();
        result = (Tuple<byte[], ulong, int>) null;
      }
      return (byte[]) null;
    }

    public async Task SendPingAsync(CancellationToken token = default (CancellationToken))
    {
      token.ThrowIfCancellationRequested();
      PingRequest pingRequest = new PingRequest();
      using (MemoryStream memory = new MemoryStream())
      {
        using (BinaryWriter writer = new BinaryWriter((Stream) memory))
        {
          pingRequest.SerializeBody(writer);
          await this.Send(memory.ToArray(), (TLMethod) pingRequest, token).ConfigureAwait(false);
        }
      }
      byte[] numArray = await this.Receive((TLMethod) pingRequest, token).ConfigureAwait(false);
    }

    private bool processMessage(
      ulong messageId,
      int sequence,
      BinaryReader messageReader,
      TLMethod request,
      CancellationToken token = default (CancellationToken))
    {
      token.ThrowIfCancellationRequested();
      this.needConfirmation.Add(messageId);
      uint num = messageReader.ReadUInt32();
      messageReader.BaseStream.Position -= 4L;
      switch (num)
      {
        case 661470918:
          return this.HandleMsgDetailedInfo(messageId, sequence, messageReader);
        case 724548942:
        case 1918567619:
        case 1957577280:
        case 2027216577:
        case 3556005764:
        case 3809980286:
          return this.HandleUpdate(messageId, sequence, messageReader);
        case 812830625:
          return this.HandleGzipPacked(messageId, sequence, messageReader, request, token);
        case 880243653:
          return this.HandlePong(messageId, sequence, messageReader, request);
        case 1658238041:
          return this.HandleMsgsAck(messageId, sequence, messageReader);
        case 1945237724:
          return this.HandleContainer(messageId, sequence, messageReader, request, token);
        case 2059302892:
          return this.HandlePing(messageId, sequence, messageReader);
        case 2663516424:
          return this.HandleNewSessionCreated(messageId, sequence, messageReader);
        case 2817521681:
          return this.HandleBadMsgNotification(messageId, sequence, messageReader);
        case 2924480661:
          return this.HandleFutureSalts(messageId, sequence, messageReader);
        case 3987424379:
          return this.HandleBadServerSalt(messageId, sequence, messageReader, request, token);
        case 4082920705:
          return this.HandleRpcResult(messageId, sequence, messageReader, request);
        default:
          return false;
      }
    }

    private bool HandleUpdate(ulong messageId, int sequence, BinaryReader messageReader) => false;

    private bool HandleGzipPacked(
      ulong messageId,
      int sequence,
      BinaryReader messageReader,
      TLMethod request,
      CancellationToken token = default (CancellationToken))
    {
      token.ThrowIfCancellationRequested();
      messageReader.ReadUInt32();
      byte[] buffer = Serializers.Bytes.Read(messageReader);
      using (MemoryStream memoryStream1 = new MemoryStream())
      {
        using (MemoryStream memoryStream2 = new MemoryStream(buffer, false))
        {
          using (GZipStream gzipStream = new GZipStream((Stream) memoryStream2, CompressionMode.Decompress))
          {
            gzipStream.CopyTo((Stream) memoryStream1);
            memoryStream1.Position = 0L;
          }
        }
        using (BinaryReader messageReader1 = new BinaryReader((Stream) memoryStream1))
          this.processMessage(messageId, sequence, messageReader1, request, token);
      }
      return true;
    }

    private bool HandleRpcResult(
      ulong messageId,
      int sequence,
      BinaryReader messageReader,
      TLMethod request)
    {
      messageReader.ReadUInt32();
      if ((long) messageReader.ReadUInt64() == request.MessageId)
        request.ConfirmReceived = true;
      switch (messageReader.ReadUInt32())
      {
        case 558156313:
          messageReader.ReadInt32();
          string str = Serializers.String.Read(messageReader);
          if (str.StartsWith("FLOOD_WAIT_"))
            throw new FloodException(TimeSpan.FromSeconds((double) int.Parse(Regex.Match(str, "\\d+").Value)));
          if (str.StartsWith("PHONE_MIGRATE_"))
            throw new PhoneMigrationException(int.Parse(Regex.Match(str, "\\d+").Value));
          if (str.StartsWith("FILE_MIGRATE_"))
            throw new FileMigrationException(int.Parse(Regex.Match(str, "\\d+").Value));
          if (str.StartsWith("USER_MIGRATE_"))
            throw new UserMigrationException(int.Parse(Regex.Match(str, "\\d+").Value));
          if (str.StartsWith("NETWORK_MIGRATE_"))
            throw new NetworkMigrationException(int.Parse(Regex.Match(str, "\\d+").Value));
          switch (str)
          {
            case "PHONE_CODE_INVALID":
              throw new InvalidPhoneCodeException("The numeric code used to authenticate does not match the numeric code sent by SMS/Telegram");
            case "SESSION_PASSWORD_NEEDED":
              throw new CloudPasswordNeededException("This Account has Cloud Password !");
            default:
              throw new InvalidOperationException(str);
          }
        case 812830625:
          byte[] buffer = Serializers.Bytes.Read(messageReader);
          using (MemoryStream memoryStream1 = new MemoryStream())
          {
            using (MemoryStream memoryStream2 = new MemoryStream(buffer, false))
            {
              using (GZipStream gzipStream = new GZipStream((Stream) memoryStream2, CompressionMode.Decompress))
              {
                gzipStream.CopyTo((Stream) memoryStream1);
                memoryStream1.Position = 0L;
              }
            }
            using (BinaryReader stream = new BinaryReader((Stream) memoryStream1))
            {
              request.DeserializeResponse(stream);
              break;
            }
          }
        default:
          messageReader.BaseStream.Position -= 4L;
          request.DeserializeResponse(messageReader);
          break;
      }
      return false;
    }

    private bool HandleMsgDetailedInfo(ulong messageId, int sequence, BinaryReader messageReader)
    {
      return false;
    }

    private bool HandleBadMsgNotification(
      ulong messageId,
      int sequence,
      BinaryReader messageReader)
    {
      messageReader.ReadUInt32();
      messageReader.ReadUInt64();
      messageReader.ReadInt32();
      switch (messageReader.ReadInt32())
      {
        case 16:
          throw new InvalidOperationException("msg_id too low (most likely, client time is wrong; it would be worthwhile to synchronize it using msg_id notifications and re-send the original message with the “correct” msg_id or wrap it in a container with a new msg_id if the original message had waited too long on the client to be transmitted)");
        case 17:
          throw new InvalidOperationException("msg_id too high (similar to the previous case, the client time has to be synchronized, and the message re-sent with the correct msg_id)");
        case 18:
          throw new InvalidOperationException("incorrect two lower order msg_id bits (the server expects client message msg_id to be divisible by 4)");
        case 19:
          throw new InvalidOperationException("container msg_id is the same as msg_id of a previously received message (this must never happen)");
        case 20:
          throw new InvalidOperationException("message too old, and it cannot be verified whether the server has received a message with this msg_id or not");
        case 32:
          throw new InvalidOperationException("msg_seqno too low (the server has already received a message with a lower msg_id but with either a higher or an equal and odd seqno)");
        case 33:
          throw new InvalidOperationException(" msg_seqno too high (similarly, there is a message with a higher msg_id but with either a lower or an equal and odd seqno)");
        case 34:
          throw new InvalidOperationException("an even msg_seqno expected (irrelevant message), but odd received");
        case 35:
          throw new InvalidOperationException("odd msg_seqno expected (relevant message), but even received");
        case 48:
          throw new InvalidOperationException("incorrect server salt (in this case, the bad_server_salt response is received with the correct salt, and the message is to be re-sent with it)");
        case 64:
          throw new InvalidOperationException("invalid container");
        default:
          throw new NotImplementedException("This should never happens");
      }
    }

    private bool HandleBadServerSalt(
      ulong messageId,
      int sequence,
      BinaryReader messageReader,
      TLMethod request,
      CancellationToken token = default (CancellationToken))
    {
      token.ThrowIfCancellationRequested();
      messageReader.ReadUInt32();
      messageReader.ReadUInt64();
      messageReader.ReadInt32();
      messageReader.ReadInt32();
      this.session.Salt = messageReader.ReadUInt64();
      this.Send(request, token);
      return true;
    }

    private bool HandleMsgsAck(ulong messageId, int sequence, BinaryReader messageReader) => false;

    private bool HandleNewSessionCreated(ulong messageId, int sequence, BinaryReader messageReader)
    {
      return false;
    }

    private bool HandleFutureSalts(ulong messageId, int sequence, BinaryReader messageReader)
    {
      messageReader.ReadUInt32();
      messageReader.ReadUInt64();
      messageReader.BaseStream.Position -= 12L;
      throw new NotImplementedException("Handle future server salts function isn't implemented.");
    }

    private bool HandlePong(
      ulong messageId,
      int sequence,
      BinaryReader messageReader,
      TLMethod request)
    {
      messageReader.ReadUInt32();
      if ((long) messageReader.ReadUInt64() == request.MessageId)
        request.ConfirmReceived = true;
      return false;
    }

    private bool HandlePing(ulong messageId, int sequence, BinaryReader messageReader) => false;

    private bool HandleContainer(
      ulong messageId,
      int sequence,
      BinaryReader messageReader,
      TLMethod request,
      CancellationToken token = default (CancellationToken))
    {
      token.ThrowIfCancellationRequested();
      messageReader.ReadUInt32();
      int num1 = messageReader.ReadInt32();
      for (int index = 0; index < num1; ++index)
      {
        ulong messageId1 = messageReader.ReadUInt64();
        messageReader.ReadInt32();
        int num2 = messageReader.ReadInt32();
        long position = messageReader.BaseStream.Position;
        try
        {
          if (!this.processMessage(messageId1, sequence, messageReader, request, token))
            messageReader.BaseStream.Position = position + (long) num2;
        }
        catch (Exception ex)
        {
          Debug.WriteLine("[ex] MtProtoSender: " + ex.Message);
          messageReader.BaseStream.Position = position + (long) num2;
        }
      }
      return false;
    }

    private MemoryStream makeMemory(int len) => new MemoryStream(new byte[len], 0, len, true, true);
  }
}
