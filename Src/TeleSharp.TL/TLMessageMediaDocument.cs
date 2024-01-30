// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLMessageMediaDocument
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-203411800)]
  public class TLMessageMediaDocument : TLAbsMessageMedia
  {
    public override int Constructor => -203411800;

    public TLAbsDocument Document { get; set; }

    public string Caption { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Document = (TLAbsDocument) ObjectUtils.DeserializeObject(br);
      this.Caption = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Document, bw);
      StringUtil.Serialize(this.Caption, bw);
    }
  }
}
