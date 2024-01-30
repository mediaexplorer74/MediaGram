// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestGetMessageEditData
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-39416522)]
  public class TLRequestGetMessageEditData : TLMethod
  {
    public override int Constructor => -39416522;

    public TLAbsInputPeer Peer { get; set; }

    public int Id { get; set; }

    public TLMessageEditData Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.Id = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.Id);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLMessageEditData) ObjectUtils.DeserializeObject(br);
    }
  }
}
