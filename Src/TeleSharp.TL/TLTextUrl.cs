// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLTextUrl
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1009288385)]
  public class TLTextUrl : TLAbsRichText
  {
    public override int Constructor => 1009288385;

    public TLAbsRichText Text { get; set; }

    public string Url { get; set; }

    public long WebpageId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Text = (TLAbsRichText) ObjectUtils.DeserializeObject(br);
      this.Url = StringUtil.Deserialize(br);
      this.WebpageId = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Text, bw);
      StringUtil.Serialize(this.Url, bw);
      bw.Write(this.WebpageId);
    }
  }
}
