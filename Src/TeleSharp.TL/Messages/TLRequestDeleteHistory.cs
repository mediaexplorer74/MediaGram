// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestDeleteHistory
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(469850889)]
  public class TLRequestDeleteHistory : TLMethod
  {
    public override int Constructor => 469850889;

    public int Flags { get; set; }

    public bool JustClear { get; set; }

    public TLAbsInputPeer Peer { get; set; }

    public int MaxId { get; set; }

    public TLAffectedHistory Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.JustClear ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.JustClear = (this.Flags & 1) != 0;
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.MaxId = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.MaxId);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAffectedHistory) ObjectUtils.DeserializeObject(br);
    }
  }
}
