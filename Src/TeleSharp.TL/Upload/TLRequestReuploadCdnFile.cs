// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Upload.TLRequestReuploadCdnFile
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Upload
{
  [TLObject(779755552)]
  public class TLRequestReuploadCdnFile : TLMethod
  {
    public override int Constructor => 779755552;

    public byte[] FileToken { get; set; }

    public byte[] RequestToken { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.FileToken = BytesUtil.Deserialize(br);
      this.RequestToken = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BytesUtil.Serialize(this.FileToken, bw);
      BytesUtil.Serialize(this.RequestToken, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = BoolUtil.Deserialize(br);
    }
  }
}
