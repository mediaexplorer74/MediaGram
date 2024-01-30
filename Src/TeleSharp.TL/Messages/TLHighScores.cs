// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLHighScores
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-1707344487)]
  public class TLHighScores : TLObject
  {
    public override int Constructor => -1707344487;

    public TLVector<TLHighScore> Scores { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Scores = ObjectUtils.DeserializeVector<TLHighScore>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Scores, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
