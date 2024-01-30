// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLAllStickers
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-302170017)]
  public class TLAllStickers : TLAbsAllStickers
  {
    public override int Constructor => -302170017;

    public int Hash { get; set; }

    public TLVector<TLStickerSet> Sets { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Hash = br.ReadInt32();
      this.Sets = ObjectUtils.DeserializeVector<TLStickerSet>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Hash);
      ObjectUtils.SerializeObject((object) this.Sets, bw);
    }
  }
}
