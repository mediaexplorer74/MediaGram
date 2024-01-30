// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Channels.TLRequestDeleteMessages
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;
using TeleSharp.TL.Messages;

#nullable disable
namespace TeleSharp.TL.Channels
{
  [TLObject(-2067661490)]
  public class TLRequestDeleteMessages : TLMethod
  {
    public override int Constructor => -2067661490;

    public TLAbsInputChannel Channel { get; set; }

    public TLVector<int> Id { get; set; }

    public TLAffectedMessages Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Channel = (TLAbsInputChannel) ObjectUtils.DeserializeObject(br);
      this.Id = ObjectUtils.DeserializeVector<int>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Channel, bw);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAffectedMessages) ObjectUtils.DeserializeObject(br);
    }
  }
}
