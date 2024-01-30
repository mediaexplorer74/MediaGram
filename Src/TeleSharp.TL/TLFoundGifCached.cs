// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLFoundGifCached
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1670052855)]
  public class TLFoundGifCached : TLAbsFoundGif
  {
    public override int Constructor => -1670052855;

    public string Url { get; set; }

    public TLAbsPhoto Photo { get; set; }

    public TLAbsDocument Document { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Url = StringUtil.Deserialize(br);
      this.Photo = (TLAbsPhoto) ObjectUtils.DeserializeObject(br);
      this.Document = (TLAbsDocument) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Url, bw);
      ObjectUtils.SerializeObject((object) this.Photo, bw);
      ObjectUtils.SerializeObject((object) this.Document, bw);
    }
  }
}
