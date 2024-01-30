// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLFileLocation
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1406570614)]
  public class TLFileLocation : TLAbsFileLocation
  {
    public override int Constructor => 1406570614;

    public int DcId { get; set; }

    public long VolumeId { get; set; }

    public int LocalId { get; set; }

    public long Secret { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.DcId = br.ReadInt32();
      this.VolumeId = br.ReadInt64();
      this.LocalId = br.ReadInt32();
      this.Secret = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.DcId);
      bw.Write(this.VolumeId);
      bw.Write(this.LocalId);
      bw.Write(this.Secret);
    }
  }
}
