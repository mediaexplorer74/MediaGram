// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Photos.TLRequestUploadProfilePhoto
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Photos
{
  [TLObject(1328726168)]
  public class TLRequestUploadProfilePhoto : TLMethod
  {
    public override int Constructor => 1328726168;

    public TLAbsInputFile File { get; set; }

    public TLPhoto Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.File = (TLAbsInputFile) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.File, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLPhoto) ObjectUtils.DeserializeObject(br);
    }
  }
}
