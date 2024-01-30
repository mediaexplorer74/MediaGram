// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.Session
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using System;
using System.IO;
using TeleSharp.TL;
using TLSharp.Core.MTProto;
using TLSharp.Core.MTProto.Crypto;

#nullable disable
namespace TLSharp.Core
{
  public class Session
  {
    internal object Lock = new object();
    private const string defaultConnectionAddress = "149.154.175.100";
    private const int defaultConnectionPort = 443;
    private Random random;
    private ISessionStore store;

    public string SessionUserId { get; set; }

    internal DataCenter DataCenter { get; set; }

    public AuthKey AuthKey { get; set; }

    public ulong Id { get; set; }

    public int Sequence { get; set; }

    public ulong Salt { get; set; }

    public int TimeOffset { get; set; }

    public long LastMessageId { get; set; }

    public int SessionExpires { get; set; }

    public TLUser TLUser { get; set; }

    public Session(ISessionStore store)
    {
      this.random = new Random();
      this.store = store;
    }

    public byte[] ToBytes()
    {
      using (MemoryStream output = new MemoryStream())
      {
        using (BinaryWriter binaryWriter = new BinaryWriter((Stream) output))
        {
          binaryWriter.Write(this.Id);
          binaryWriter.Write(this.Sequence);
          binaryWriter.Write(this.Salt);
          binaryWriter.Write(this.LastMessageId);
          binaryWriter.Write(this.TimeOffset);
          Serializers.String.Write(binaryWriter, this.DataCenter.Address);
          binaryWriter.Write(this.DataCenter.Port);
          if (this.TLUser != null)
          {
            binaryWriter.Write(1);
            binaryWriter.Write(this.SessionExpires);
            ObjectUtils.SerializeObject((object) this.TLUser, binaryWriter);
          }
          else
            binaryWriter.Write(0);
          Serializers.Bytes.Write(binaryWriter, this.AuthKey.Data);
          return output.ToArray();
        }
      }
    }

    public static Session FromBytes(byte[] buffer, ISessionStore store, string sessionUserId)
    {
      using (MemoryStream input = new MemoryStream(buffer))
      {
        using (BinaryReader binaryReader = new BinaryReader((Stream) input))
        {
          ulong num1 = binaryReader.ReadUInt64();
          int num2 = binaryReader.ReadInt32();
          ulong num3 = binaryReader.ReadUInt64();
          long num4 = binaryReader.ReadInt64();
          int num5 = binaryReader.ReadInt32();
          string address = Serializers.String.Read(binaryReader);
          int port = binaryReader.ReadInt32();
          bool flag = binaryReader.ReadInt32() == 1;
          int num6 = 0;
          TLUser tlUser = (TLUser) null;
          if (flag)
          {
            num6 = binaryReader.ReadInt32();
            tlUser = (TLUser) ObjectUtils.DeserializeObject(binaryReader);
          }
          byte[] data = Serializers.Bytes.Read(binaryReader);
          DataCenter dataCenter = new DataCenter(address, port);
          return new Session(store)
          {
            AuthKey = new AuthKey(data),
            Id = num1,
            Salt = num3,
            Sequence = num2,
            LastMessageId = num4,
            TimeOffset = num5,
            SessionExpires = num6,
            TLUser = tlUser,
            SessionUserId = sessionUserId,
            DataCenter = dataCenter
          };
        }
      }
    }

    public void Save() => this.store.Save(this);

    public static Session TryLoadOrCreateNew(ISessionStore store, string sessionUserId)
    {
      DataCenter dataCenter = new DataCenter("149.154.175.100", 443);
      Session session = store.Load(sessionUserId);
      if (session == null)
        session = new Session(store)
        {
          Id = Session.GenerateRandomUlong(),
          SessionUserId = sessionUserId,
          DataCenter = dataCenter
        };
      return session;
    }

    private static ulong GenerateRandomUlong()
    {
      Random random = new Random();
      return (ulong) random.Next() << 32 | (ulong) random.Next();
    }

    public long GetNewMessageId()
    {
      long int64 = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds);
      long newMessageId = int64 / 1000L + (long) this.TimeOffset << 32 | int64 % 1000L << 22 | (long) (this.random.Next(524288) << 2);
      if (this.LastMessageId >= newMessageId)
        newMessageId = this.LastMessageId + 4L;
      this.LastMessageId = newMessageId;
      return newMessageId;
    }
  }
}
