// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLDocumentAttributeImageSize
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1815593308)]
  public class TLDocumentAttributeImageSize : TLAbsDocumentAttribute
  {
    public override int Constructor => 1815593308;

    public int W { get; set; }

    public int H { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.W = br.ReadInt32();
      this.H = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.W);
      bw.Write(this.H);
    }
  }
}
