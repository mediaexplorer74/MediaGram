// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLDocumentAttributeSticker
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1662637586)]
  public class TLDocumentAttributeSticker : TLAbsDocumentAttribute
  {
    public override int Constructor => 1662637586;

    public int Flags { get; set; }

    public bool Mask { get; set; }

    public string Alt { get; set; }

    public TLAbsInputStickerSet Stickerset { get; set; }

    public TLMaskCoords MaskCoords { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Mask ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.MaskCoords != null ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Mask = (this.Flags & 2) != 0;
      this.Alt = StringUtil.Deserialize(br);
      this.Stickerset = (TLAbsInputStickerSet) ObjectUtils.DeserializeObject(br);
      if ((this.Flags & 1) != 0)
        this.MaskCoords = (TLMaskCoords) ObjectUtils.DeserializeObject(br);
      else
        this.MaskCoords = (TLMaskCoords) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      StringUtil.Serialize(this.Alt, bw);
      ObjectUtils.SerializeObject((object) this.Stickerset, bw);
      if ((this.Flags & 1) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.MaskCoords, bw);
    }
  }
}
