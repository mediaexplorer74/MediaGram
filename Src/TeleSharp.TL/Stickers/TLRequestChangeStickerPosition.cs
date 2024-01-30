// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Stickers.TLRequestChangeStickerPosition
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Stickers
{
  [TLObject(1322714570)]
  public class TLRequestChangeStickerPosition : TLMethod
  {
    public override int Constructor => 1322714570;

    public TLAbsInputDocument Sticker { get; set; }

    public int Position { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Sticker = (TLAbsInputDocument) ObjectUtils.DeserializeObject(br);
      this.Position = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Sticker, bw);
      bw.Write(this.Position);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = BoolUtil.Deserialize(br);
    }
  }
}
