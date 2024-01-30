// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLTopPeerCategoryPeers
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-75283823)]
  public class TLTopPeerCategoryPeers : TLObject
  {
    public override int Constructor => -75283823;

    public TLAbsTopPeerCategory Category { get; set; }

    public int Count { get; set; }

    public TLVector<TLTopPeer> Peers { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Category = (TLAbsTopPeerCategory) ObjectUtils.DeserializeObject(br);
      this.Count = br.ReadInt32();
      this.Peers = ObjectUtils.DeserializeVector<TLTopPeer>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Category, bw);
      bw.Write(this.Count);
      ObjectUtils.SerializeObject((object) this.Peers, bw);
    }
  }
}
