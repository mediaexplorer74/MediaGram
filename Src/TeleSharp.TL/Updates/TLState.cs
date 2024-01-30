// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Updates.TLState
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Updates
{
  [TLObject(-1519637954)]
  public class TLState : TLObject
  {
    public override int Constructor => -1519637954;

    public int Pts { get; set; }

    public int Qts { get; set; }

    public int Date { get; set; }

    public int Seq { get; set; }

    public int UnreadCount { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Pts = br.ReadInt32();
      this.Qts = br.ReadInt32();
      this.Date = br.ReadInt32();
      this.Seq = br.ReadInt32();
      this.UnreadCount = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Pts);
      bw.Write(this.Qts);
      bw.Write(this.Date);
      bw.Write(this.Seq);
      bw.Write(this.UnreadCount);
    }
  }
}
