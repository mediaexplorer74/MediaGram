// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLStickerSet
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-1240849242)]
  public class TLStickerSet : TLObject
  {
    public override int Constructor => -1240849242;

    public TeleSharp.TL.TLStickerSet Set { get; set; }

    public TLVector<TLStickerPack> Packs { get; set; }

    public TLVector<TLAbsDocument> Documents { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Set = (TeleSharp.TL.TLStickerSet) ObjectUtils.DeserializeObject(br);
      this.Packs = ObjectUtils.DeserializeVector<TLStickerPack>(br);
      this.Documents = ObjectUtils.DeserializeVector<TLAbsDocument>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Set, bw);
      ObjectUtils.SerializeObject((object) this.Packs, bw);
      ObjectUtils.SerializeObject((object) this.Documents, bw);
    }
  }
}
