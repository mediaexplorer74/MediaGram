// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUserProfilePhoto
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-715532088)]
  public class TLUserProfilePhoto : TLAbsUserProfilePhoto
  {
    public override int Constructor => -715532088;

    public long PhotoId { get; set; }

    public TLAbsFileLocation PhotoSmall { get; set; }

    public TLAbsFileLocation PhotoBig { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PhotoId = br.ReadInt64();
      this.PhotoSmall = (TLAbsFileLocation) ObjectUtils.DeserializeObject(br);
      this.PhotoBig = (TLAbsFileLocation) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.PhotoId);
      ObjectUtils.SerializeObject((object) this.PhotoSmall, bw);
      ObjectUtils.SerializeObject((object) this.PhotoBig, bw);
    }
  }
}
