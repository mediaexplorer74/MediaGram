// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateDraftMessage
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-299124375)]
  public class TLUpdateDraftMessage : TLAbsUpdate
  {
    public override int Constructor => -299124375;

    public TLAbsPeer Peer { get; set; }

    public TLAbsDraftMessage Draft { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLAbsPeer) ObjectUtils.DeserializeObject(br);
      this.Draft = (TLAbsDraftMessage) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      ObjectUtils.SerializeObject((object) this.Draft, bw);
    }
  }
}
