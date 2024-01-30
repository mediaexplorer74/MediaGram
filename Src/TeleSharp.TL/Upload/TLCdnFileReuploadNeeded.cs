// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Upload.TLCdnFileReuploadNeeded
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Upload
{
  [TLObject(-290921362)]
  public class TLCdnFileReuploadNeeded : TLAbsCdnFile
  {
    public override int Constructor => -290921362;

    public byte[] RequestToken { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.RequestToken = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BytesUtil.Serialize(this.RequestToken, bw);
    }
  }
}
