// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLStickerSetMultiCovered
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(872932635)]
  public class TLStickerSetMultiCovered : TLAbsStickerSetCovered
  {
    public override int Constructor => 872932635;

    public TLStickerSet Set { get; set; }

    public TLVector<TLAbsDocument> Covers { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Set = (TLStickerSet) ObjectUtils.DeserializeObject(br);
      this.Covers = ObjectUtils.DeserializeVector<TLAbsDocument>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Set, bw);
      ObjectUtils.SerializeObject((object) this.Covers, bw);
    }
  }
}
