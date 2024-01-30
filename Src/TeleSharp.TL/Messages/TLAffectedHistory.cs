// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLAffectedHistory
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-1269012015)]
  public class TLAffectedHistory : TLObject
  {
    public override int Constructor => -1269012015;

    public int Pts { get; set; }

    public int PtsCount { get; set; }

    public int Offset { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Pts = br.ReadInt32();
      this.PtsCount = br.ReadInt32();
      this.Offset = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Pts);
      bw.Write(this.PtsCount);
      bw.Write(this.Offset);
    }
  }
}
