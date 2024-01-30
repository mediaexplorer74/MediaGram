// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestReadHistory
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(238054714)]
  public class TLRequestReadHistory : TLMethod
  {
    public override int Constructor => 238054714;

    public TLAbsInputPeer Peer { get; set; }

    public int MaxId { get; set; }

    public TLAffectedMessages Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.MaxId = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.MaxId);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAffectedMessages) ObjectUtils.DeserializeObject(br);
    }
  }
}
