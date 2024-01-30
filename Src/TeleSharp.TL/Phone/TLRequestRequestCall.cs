// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Phone.TLRequestRequestCall
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Phone
{
  [TLObject(1536537556)]
  public class TLRequestRequestCall : TLMethod
  {
    public override int Constructor => 1536537556;

    public TLAbsInputUser UserId { get; set; }

    public int RandomId { get; set; }

    public byte[] GAHash { get; set; }

    public TLPhoneCallProtocol Protocol { get; set; }

    public TLPhoneCall Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
      this.RandomId = br.ReadInt32();
      this.GAHash = BytesUtil.Deserialize(br);
      this.Protocol = (TLPhoneCallProtocol) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.UserId, bw);
      bw.Write(this.RandomId);
      BytesUtil.Serialize(this.GAHash, bw);
      ObjectUtils.SerializeObject((object) this.Protocol, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLPhoneCall) ObjectUtils.DeserializeObject(br);
    }
  }
}
