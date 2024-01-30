// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLDocumentAttributeFilename
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(358154344)]
  public class TLDocumentAttributeFilename : TLAbsDocumentAttribute
  {
    public override int Constructor => 358154344;

    public string FileName { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.FileName = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.FileName, bw);
    }
  }
}
