// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestStartBot
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-421563528)]
  public class TLRequestStartBot : TLMethod
  {
    public override int Constructor => -421563528;

    public TLAbsInputUser Bot { get; set; }

    public TLAbsInputPeer Peer { get; set; }

    public long RandomId { get; set; }

    public string StartParam { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Bot = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.RandomId = br.ReadInt64();
      this.StartParam = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Bot, bw);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.RandomId);
      StringUtil.Serialize(this.StartParam, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
    }
  }
}
