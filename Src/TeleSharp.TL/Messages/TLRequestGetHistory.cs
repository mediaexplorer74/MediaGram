// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestGetHistory
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-1347868602)]
  public class TLRequestGetHistory : TLMethod
  {
    public override int Constructor => -1347868602;

    public TLAbsInputPeer Peer { get; set; }

    public int OffsetId { get; set; }

    public int OffsetDate { get; set; }

    public int AddOffset { get; set; }

    public int Limit { get; set; }

    public int MaxId { get; set; }

    public int MinId { get; set; }

    public TLAbsMessages Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.OffsetId = br.ReadInt32();
      this.OffsetDate = br.ReadInt32();
      this.AddOffset = br.ReadInt32();
      this.Limit = br.ReadInt32();
      this.MaxId = br.ReadInt32();
      this.MinId = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.OffsetId);
      bw.Write(this.OffsetDate);
      bw.Write(this.AddOffset);
      bw.Write(this.Limit);
      bw.Write(this.MaxId);
      bw.Write(this.MinId);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsMessages) ObjectUtils.DeserializeObject(br);
    }
  }
}
