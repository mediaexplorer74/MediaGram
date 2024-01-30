// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLDocumentAttributeVideo
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(250621158)]
  public class TLDocumentAttributeVideo : TLAbsDocumentAttribute
  {
    public override int Constructor => 250621158;

    public int Flags { get; set; }

    public bool RoundMessage { get; set; }

    public int Duration { get; set; }

    public int W { get; set; }

    public int H { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.RoundMessage ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.RoundMessage = (this.Flags & 1) != 0;
      this.Duration = br.ReadInt32();
      this.W = br.ReadInt32();
      this.H = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Duration);
      bw.Write(this.W);
      bw.Write(this.H);
    }
  }
}
