// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateDialogPinned
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-686710068)]
  public class TLUpdateDialogPinned : TLAbsUpdate
  {
    public override int Constructor => -686710068;

    public int Flags { get; set; }

    public bool Pinned { get; set; }

    public TLAbsPeer Peer { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Pinned ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Pinned = (this.Flags & 1) != 0;
      this.Peer = (TLAbsPeer) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
    }
  }
}
