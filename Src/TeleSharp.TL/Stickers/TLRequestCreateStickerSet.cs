// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Stickers.TLRequestCreateStickerSet
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Stickers
{
  [TLObject(-1680314774)]
  public class TLRequestCreateStickerSet : TLMethod
  {
    public override int Constructor => -1680314774;

    public int Flags { get; set; }

    public bool Masks { get; set; }

    public TLAbsInputUser UserId { get; set; }

    public string Title { get; set; }

    public string ShortName { get; set; }

    public TLVector<TLInputStickerSetItem> Stickers { get; set; }

    public TeleSharp.TL.Messages.TLStickerSet Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Masks ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Masks = (this.Flags & 1) != 0;
      this.UserId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
      this.Title = StringUtil.Deserialize(br);
      this.ShortName = StringUtil.Deserialize(br);
      this.Stickers = ObjectUtils.DeserializeVector<TLInputStickerSetItem>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.UserId, bw);
      StringUtil.Serialize(this.Title, bw);
      StringUtil.Serialize(this.ShortName, bw);
      ObjectUtils.SerializeObject((object) this.Stickers, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TeleSharp.TL.Messages.TLStickerSet) ObjectUtils.DeserializeObject(br);
    }
  }
}
