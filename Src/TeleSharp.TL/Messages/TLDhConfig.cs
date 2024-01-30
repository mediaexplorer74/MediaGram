// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLDhConfig
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(740433629)]
  public class TLDhConfig : TLAbsDhConfig
  {
    public override int Constructor => 740433629;

    public int G { get; set; }

    public byte[] P { get; set; }

    public int Version { get; set; }

    public byte[] Random { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.G = br.ReadInt32();
      this.P = BytesUtil.Deserialize(br);
      this.Version = br.ReadInt32();
      this.Random = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.G);
      BytesUtil.Serialize(this.P, bw);
      bw.Write(this.Version);
      BytesUtil.Serialize(this.Random, bw);
    }
  }
}
