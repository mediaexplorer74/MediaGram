// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestGetDhConfig
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(651135312)]
  public class TLRequestGetDhConfig : TLMethod
  {
    public override int Constructor => 651135312;

    public int Version { get; set; }

    public int RandomLength { get; set; }

    public TLAbsDhConfig Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Version = br.ReadInt32();
      this.RandomLength = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Version);
      bw.Write(this.RandomLength);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsDhConfig) ObjectUtils.DeserializeObject(br);
    }
  }
}
