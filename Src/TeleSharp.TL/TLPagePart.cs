// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLPagePart
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1913754556)]
  public class TLPagePart : TLAbsPage
  {
    public override int Constructor => -1913754556;

    public TLVector<TLAbsPageBlock> Blocks { get; set; }

    public TLVector<TLAbsPhoto> Photos { get; set; }

    public TLVector<TLAbsDocument> Videos { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Blocks = ObjectUtils.DeserializeVector<TLAbsPageBlock>(br);
      this.Photos = ObjectUtils.DeserializeVector<TLAbsPhoto>(br);
      this.Videos = ObjectUtils.DeserializeVector<TLAbsDocument>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Blocks, bw);
      ObjectUtils.SerializeObject((object) this.Photos, bw);
      ObjectUtils.SerializeObject((object) this.Videos, bw);
    }
  }
}
