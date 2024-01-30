// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLMessageActionGameScore
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1834538890)]
  public class TLMessageActionGameScore : TLAbsMessageAction
  {
    public override int Constructor => -1834538890;

    public long GameId { get; set; }

    public int Score { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.GameId = br.ReadInt64();
      this.Score = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.GameId);
      bw.Write(this.Score);
    }
  }
}
