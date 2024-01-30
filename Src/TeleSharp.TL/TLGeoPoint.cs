// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLGeoPoint
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(541710092)]
  public class TLGeoPoint : TLAbsGeoPoint
  {
    public override int Constructor => 541710092;

    public double Long { get; set; }

    public double Lat { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Long = br.ReadDouble();
      this.Lat = br.ReadDouble();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Long);
      bw.Write(this.Lat);
    }
  }
}
