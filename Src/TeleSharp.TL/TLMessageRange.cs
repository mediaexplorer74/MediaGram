// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLMessageRange
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(182649427)]
  public class TLMessageRange : TLObject
  {
    public override int Constructor => 182649427;

    public int MinId { get; set; }

    public int MaxId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.MinId = br.ReadInt32();
      this.MaxId = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.MinId);
      bw.Write(this.MaxId);
    }
  }
}
