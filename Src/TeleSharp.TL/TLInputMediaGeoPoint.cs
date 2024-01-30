// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputMediaGeoPoint
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-104578748)]
  public class TLInputMediaGeoPoint : TLAbsInputMedia
  {
    public override int Constructor => -104578748;

    public TLAbsInputGeoPoint GeoPoint { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.GeoPoint = (TLAbsInputGeoPoint) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.GeoPoint, bw);
    }
  }
}
