// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputMediaUploadedDocument
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-797904407)]
  public class TLInputMediaUploadedDocument : TLAbsInputMedia
  {
    public override int Constructor => -797904407;

    public int Flags { get; set; }

    public TLAbsInputFile File { get; set; }

    public string MimeType { get; set; }

    public TLVector<TLAbsDocumentAttribute> Attributes { get; set; }

    public string Caption { get; set; }

    public TLVector<TLAbsInputDocument> Stickers { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Stickers != null ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.File = (TLAbsInputFile) ObjectUtils.DeserializeObject(br);
      this.MimeType = StringUtil.Deserialize(br);
      this.Attributes = ObjectUtils.DeserializeVector<TLAbsDocumentAttribute>(br);
      this.Caption = StringUtil.Deserialize(br);
      if ((this.Flags & 1) != 0)
        this.Stickers = ObjectUtils.DeserializeVector<TLAbsInputDocument>(br);
      else
        this.Stickers = (TLVector<TLAbsInputDocument>) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.File, bw);
      StringUtil.Serialize(this.MimeType, bw);
      ObjectUtils.SerializeObject((object) this.Attributes, bw);
      StringUtil.Serialize(this.Caption, bw);
      if ((this.Flags & 1) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.Stickers, bw);
    }
  }
}
