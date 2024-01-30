// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Channels.TLRequestKickFromChannel
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Channels
{
  [TLObject(-1502421484)]
  public class TLRequestKickFromChannel : TLMethod
  {
    public override int Constructor => -1502421484;

    public TLAbsInputChannel Channel { get; set; }

    public TLAbsInputUser UserId { get; set; }

    public bool Kicked { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Channel = (TLAbsInputChannel) ObjectUtils.DeserializeObject(br);
      this.UserId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
      this.Kicked = BoolUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Channel, bw);
      ObjectUtils.SerializeObject((object) this.UserId, bw);
      BoolUtil.Serialize(this.Kicked, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
    }
  }
}
