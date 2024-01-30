// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLPhoneConnection
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1655957568)]
  public class TLPhoneConnection : TLObject
  {
    public override int Constructor => -1655957568;

    public long Id { get; set; }

    public string Ip { get; set; }

    public string Ipv6 { get; set; }

    public int Port { get; set; }

    public byte[] PeerTag { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt64();
      this.Ip = StringUtil.Deserialize(br);
      this.Ipv6 = StringUtil.Deserialize(br);
      this.Port = br.ReadInt32();
      this.PeerTag = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      StringUtil.Serialize(this.Ip, bw);
      StringUtil.Serialize(this.Ipv6, bw);
      bw.Write(this.Port);
      BytesUtil.Serialize(this.PeerTag, bw);
    }
  }
}
