// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLFileLocationUnavailable
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(2086234950)]
  public class TLFileLocationUnavailable : TLAbsFileLocation
  {
    public override int Constructor => 2086234950;

    public long VolumeId { get; set; }

    public int LocalId { get; set; }

    public long Secret { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.VolumeId = br.ReadInt64();
      this.LocalId = br.ReadInt32();
      this.Secret = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.VolumeId);
      bw.Write(this.LocalId);
      bw.Write(this.Secret);
    }
  }
}
