// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLMessageMediaGeo
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1457575028)]
  public class TLMessageMediaGeo : TLAbsMessageMedia
  {
    public override int Constructor => 1457575028;

    public TLAbsGeoPoint Geo { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Geo = (TLAbsGeoPoint) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Geo, bw);
    }
  }
}
