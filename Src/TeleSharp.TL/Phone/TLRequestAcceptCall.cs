// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Phone.TLRequestAcceptCall
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Phone
{
  [TLObject(1003664544)]
  public class TLRequestAcceptCall : TLMethod
  {
    public override int Constructor => 1003664544;

    public TLInputPhoneCall Peer { get; set; }

    public byte[] GB { get; set; }

    public TLPhoneCallProtocol Protocol { get; set; }

    public TLPhoneCall Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLInputPhoneCall) ObjectUtils.DeserializeObject(br);
      this.GB = BytesUtil.Deserialize(br);
      this.Protocol = (TLPhoneCallProtocol) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      BytesUtil.Serialize(this.GB, bw);
      ObjectUtils.SerializeObject((object) this.Protocol, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLPhoneCall) ObjectUtils.DeserializeObject(br);
    }
  }
}
