// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLPageBlockAuthorDate
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1162877472)]
  public class TLPageBlockAuthorDate : TLAbsPageBlock
  {
    public override int Constructor => -1162877472;

    public TLAbsRichText Author { get; set; }

    public int PublishedDate { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Author = (TLAbsRichText) ObjectUtils.DeserializeObject(br);
      this.PublishedDate = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Author, bw);
      bw.Write(this.PublishedDate);
    }
  }
}
