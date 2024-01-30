// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLMaskCoords
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1361650766)]
  public class TLMaskCoords : TLObject
  {
    public override int Constructor => -1361650766;

    public int N { get; set; }

    public double X { get; set; }

    public double Y { get; set; }

    public double Zoom { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.N = br.ReadInt32();
      this.X = br.ReadDouble();
      this.Y = br.ReadDouble();
      this.Zoom = br.ReadDouble();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.N);
      bw.Write(this.X);
      bw.Write(this.Y);
      bw.Write(this.Zoom);
    }
  }
}
