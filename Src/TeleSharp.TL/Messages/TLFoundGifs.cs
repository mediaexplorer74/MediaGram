// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLFoundGifs
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(1158290442)]
  public class TLFoundGifs : TLObject
  {
    public override int Constructor => 1158290442;

    public int NextOffset { get; set; }

    public TLVector<TLAbsFoundGif> Results { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.NextOffset = br.ReadInt32();
      this.Results = ObjectUtils.DeserializeVector<TLAbsFoundGif>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.NextOffset);
      ObjectUtils.SerializeObject((object) this.Results, bw);
    }
  }
}
