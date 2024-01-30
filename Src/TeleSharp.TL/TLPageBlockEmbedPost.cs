// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLPageBlockEmbedPost
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(690781161)]
  public class TLPageBlockEmbedPost : TLAbsPageBlock
  {
    public override int Constructor => 690781161;

    public string Url { get; set; }

    public long WebpageId { get; set; }

    public long AuthorPhotoId { get; set; }

    public string Author { get; set; }

    public int Date { get; set; }

    public TLVector<TLAbsPageBlock> Blocks { get; set; }

    public TLAbsRichText Caption { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Url = StringUtil.Deserialize(br);
      this.WebpageId = br.ReadInt64();
      this.AuthorPhotoId = br.ReadInt64();
      this.Author = StringUtil.Deserialize(br);
      this.Date = br.ReadInt32();
      this.Blocks = ObjectUtils.DeserializeVector<TLAbsPageBlock>(br);
      this.Caption = (TLAbsRichText) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Url, bw);
      bw.Write(this.WebpageId);
      bw.Write(this.AuthorPhotoId);
      StringUtil.Serialize(this.Author, bw);
      bw.Write(this.Date);
      ObjectUtils.SerializeObject((object) this.Blocks, bw);
      ObjectUtils.SerializeObject((object) this.Caption, bw);
    }
  }
}
