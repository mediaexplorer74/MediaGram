// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestGetMessagesViews
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-993483427)]
  public class TLRequestGetMessagesViews : TLMethod
  {
    public override int Constructor => -993483427;

    public TLAbsInputPeer Peer { get; set; }

    public TLVector<int> Id { get; set; }

    public bool Increment { get; set; }

    public TLVector<int> Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.Id = ObjectUtils.DeserializeVector<int>(br);
      this.Increment = BoolUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      ObjectUtils.SerializeObject((object) this.Id, bw);
      BoolUtil.Serialize(this.Increment, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = ObjectUtils.DeserializeVector<int>(br);
    }
  }
}
