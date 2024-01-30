// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateBotShippingQuery
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-523384512)]
  public class TLUpdateBotShippingQuery : TLAbsUpdate
  {
    public override int Constructor => -523384512;

    public long QueryId { get; set; }

    public int UserId { get; set; }

    public byte[] Payload { get; set; }

    public TLPostAddress ShippingAddress { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.QueryId = br.ReadInt64();
      this.UserId = br.ReadInt32();
      this.Payload = BytesUtil.Deserialize(br);
      this.ShippingAddress = (TLPostAddress) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.QueryId);
      bw.Write(this.UserId);
      BytesUtil.Serialize(this.Payload, bw);
      ObjectUtils.SerializeObject((object) this.ShippingAddress, bw);
    }
  }
}
