// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLPhoneCallProtocol
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1564789301)]
  public class TLPhoneCallProtocol : TLObject
  {
    public override int Constructor => -1564789301;

    public int Flags { get; set; }

    public bool UdpP2p { get; set; }

    public bool UdpReflector { get; set; }

    public int MinLayer { get; set; }

    public int MaxLayer { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.UdpP2p ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.UdpReflector ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.UdpP2p = (this.Flags & 1) != 0;
      this.UdpReflector = (this.Flags & 2) != 0;
      this.MinLayer = br.ReadInt32();
      this.MaxLayer = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.MinLayer);
      bw.Write(this.MaxLayer);
    }
  }
}
