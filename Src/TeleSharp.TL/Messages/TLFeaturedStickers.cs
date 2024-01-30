// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLFeaturedStickers
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-123893531)]
  public class TLFeaturedStickers : TLAbsFeaturedStickers
  {
    public override int Constructor => -123893531;

    public int Hash { get; set; }

    public TLVector<TLAbsStickerSetCovered> Sets { get; set; }

    public TLVector<long> Unread { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Hash = br.ReadInt32();
      this.Sets = ObjectUtils.DeserializeVector<TLAbsStickerSetCovered>(br);
      this.Unread = ObjectUtils.DeserializeVector<long>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Hash);
      ObjectUtils.SerializeObject((object) this.Sets, bw);
      ObjectUtils.SerializeObject((object) this.Unread, bw);
    }
  }
}
