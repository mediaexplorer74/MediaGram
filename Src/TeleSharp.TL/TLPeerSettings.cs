// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLPeerSettings
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-2122045747)]
  public class TLPeerSettings : TLObject
  {
    public override int Constructor => -2122045747;

    public int Flags { get; set; }

    public bool ReportSpam { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.ReportSpam ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.ReportSpam = (this.Flags & 1) != 0;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
    }
  }
}
