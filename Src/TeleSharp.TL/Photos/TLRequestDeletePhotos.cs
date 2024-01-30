// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Photos.TLRequestDeletePhotos
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Photos
{
  [TLObject(-2016444625)]
  public class TLRequestDeletePhotos : TLMethod
  {
    public override int Constructor => -2016444625;

    public TLVector<TLAbsInputPhoto> Id { get; set; }

    public TLVector<long> Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = ObjectUtils.DeserializeVector<TLAbsInputPhoto>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = ObjectUtils.DeserializeVector<long>(br);
    }
  }
}
