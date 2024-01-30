// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Photos.TLRequestUpdateProfilePhoto
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Photos
{
  [TLObject(-256159406)]
  public class TLRequestUpdateProfilePhoto : TLMethod
  {
    public override int Constructor => -256159406;

    public TLAbsInputPhoto Id { get; set; }

    public TLAbsUserProfilePhoto Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = (TLAbsInputPhoto) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsUserProfilePhoto) ObjectUtils.DeserializeObject(br);
    }
  }
}
