// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Stickers.TLRequestAddStickerToSet
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Stickers
{
  [TLObject(-2041315650)]
  public class TLRequestAddStickerToSet : TLMethod
  {
    public override int Constructor => -2041315650;

    public TLAbsInputStickerSet Stickerset { get; set; }

    public TLInputStickerSetItem Sticker { get; set; }

    public TeleSharp.TL.Messages.TLStickerSet Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Stickerset = (TLAbsInputStickerSet) ObjectUtils.DeserializeObject(br);
      this.Sticker = (TLInputStickerSetItem) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Stickerset, bw);
      ObjectUtils.SerializeObject((object) this.Sticker, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TeleSharp.TL.Messages.TLStickerSet) ObjectUtils.DeserializeObject(br);
    }
  }
}
