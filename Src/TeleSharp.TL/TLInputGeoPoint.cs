// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputGeoPoint
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-206066487)]
  public class TLInputGeoPoint : TLAbsInputGeoPoint
  {
    public override int Constructor => -206066487;

    public double Lat { get; set; }

    public double Long { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Lat = br.ReadDouble();
      this.Long = br.ReadDouble();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Lat);
      bw.Write(this.Long);
    }
  }
}
