// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateReadHistoryInbox
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1721631396)]
  public class TLUpdateReadHistoryInbox : TLAbsUpdate
  {
    public override int Constructor => -1721631396;

    public TLAbsPeer Peer { get; set; }

    public int MaxId { get; set; }

    public int Pts { get; set; }

    public int PtsCount { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLAbsPeer) ObjectUtils.DeserializeObject(br);
      this.MaxId = br.ReadInt32();
      this.Pts = br.ReadInt32();
      this.PtsCount = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.MaxId);
      bw.Write(this.Pts);
      bw.Write(this.PtsCount);
    }
  }
}
