// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateBotPrecheckoutQuery
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1563376297)]
  public class TLUpdateBotPrecheckoutQuery : TLAbsUpdate
  {
    public override int Constructor => 1563376297;

    public int Flags { get; set; }

    public long QueryId { get; set; }

    public int UserId { get; set; }

    public byte[] Payload { get; set; }

    public TLPaymentRequestedInfo Info { get; set; }

    public string ShippingOptionId { get; set; }

    public string Currency { get; set; }

    public long TotalAmount { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Info != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.ShippingOptionId != null ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.QueryId = br.ReadInt64();
      this.UserId = br.ReadInt32();
      this.Payload = BytesUtil.Deserialize(br);
      this.Info = (this.Flags & 1) == 0 ? (TLPaymentRequestedInfo) null : (TLPaymentRequestedInfo) ObjectUtils.DeserializeObject(br);
      this.ShippingOptionId = (this.Flags & 2) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Currency = StringUtil.Deserialize(br);
      this.TotalAmount = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.QueryId);
      bw.Write(this.UserId);
      BytesUtil.Serialize(this.Payload, bw);
      if ((this.Flags & 1) != 0)
        ObjectUtils.SerializeObject((object) this.Info, bw);
      if ((this.Flags & 2) != 0)
        StringUtil.Serialize(this.ShippingOptionId, bw);
      StringUtil.Serialize(this.Currency, bw);
      bw.Write(this.TotalAmount);
    }
  }
}
