// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLWebDocument
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-971322408)]
  public class TLWebDocument : TLObject
  {
    public override int Constructor => -971322408;

    public string Url { get; set; }

    public long AccessHash { get; set; }

    public int Size { get; set; }

    public string MimeType { get; set; }

    public TLVector<TLAbsDocumentAttribute> Attributes { get; set; }

    public int DcId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Url = StringUtil.Deserialize(br);
      this.AccessHash = br.ReadInt64();
      this.Size = br.ReadInt32();
      this.MimeType = StringUtil.Deserialize(br);
      this.Attributes = ObjectUtils.DeserializeVector<TLAbsDocumentAttribute>(br);
      this.DcId = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Url, bw);
      bw.Write(this.AccessHash);
      bw.Write(this.Size);
      StringUtil.Serialize(this.MimeType, bw);
      ObjectUtils.SerializeObject((object) this.Attributes, bw);
      bw.Write(this.DcId);
    }
  }
}
