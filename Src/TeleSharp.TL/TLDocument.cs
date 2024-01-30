// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLDocument
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-2027738169)]
  public class TLDocument : TLAbsDocument
  {
    public override int Constructor => -2027738169;

    public long Id { get; set; }

    public long AccessHash { get; set; }

    public int Date { get; set; }

    public string MimeType { get; set; }

    public int Size { get; set; }

    public TLAbsPhotoSize Thumb { get; set; }

    public int DcId { get; set; }

    public int Version { get; set; }

    public TLVector<TLAbsDocumentAttribute> Attributes { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt64();
      this.AccessHash = br.ReadInt64();
      this.Date = br.ReadInt32();
      this.MimeType = StringUtil.Deserialize(br);
      this.Size = br.ReadInt32();
      this.Thumb = (TLAbsPhotoSize) ObjectUtils.DeserializeObject(br);
      this.DcId = br.ReadInt32();
      this.Version = br.ReadInt32();
      this.Attributes = ObjectUtils.DeserializeVector<TLAbsDocumentAttribute>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      bw.Write(this.AccessHash);
      bw.Write(this.Date);
      StringUtil.Serialize(this.MimeType, bw);
      bw.Write(this.Size);
      ObjectUtils.SerializeObject((object) this.Thumb, bw);
      bw.Write(this.DcId);
      bw.Write(this.Version);
      ObjectUtils.SerializeObject((object) this.Attributes, bw);
    }
  }
}
