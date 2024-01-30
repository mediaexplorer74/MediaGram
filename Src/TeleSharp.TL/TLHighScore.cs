// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLHighScore
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1493171408)]
  public class TLHighScore : TLObject
  {
    public override int Constructor => 1493171408;

    public int Pos { get; set; }

    public int UserId { get; set; }

    public int Score { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Pos = br.ReadInt32();
      this.UserId = br.ReadInt32();
      this.Score = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Pos);
      bw.Write(this.UserId);
      bw.Write(this.Score);
    }
  }
}
