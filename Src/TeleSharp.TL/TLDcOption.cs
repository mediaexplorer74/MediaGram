// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLDcOption
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(98092748)]
  public class TLDcOption : TLObject
  {
    public override int Constructor => 98092748;

    public int Flags { get; set; }

    public bool Ipv6 { get; set; }

    public bool MediaOnly { get; set; }

    public bool TcpoOnly { get; set; }

    public bool Cdn { get; set; }

    public int Id { get; set; }

    public string IpAddress { get; set; }

    public int Port { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Ipv6 ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.MediaOnly ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.TcpoOnly ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.Cdn ? this.Flags | 8 : this.Flags & -9;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Ipv6 = (this.Flags & 1) != 0;
      this.MediaOnly = (this.Flags & 2) != 0;
      this.TcpoOnly = (this.Flags & 4) != 0;
      this.Cdn = (this.Flags & 8) != 0;
      this.Id = br.ReadInt32();
      this.IpAddress = StringUtil.Deserialize(br);
      this.Port = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Id);
      StringUtil.Serialize(this.IpAddress, bw);
      bw.Write(this.Port);
    }
  }
}
