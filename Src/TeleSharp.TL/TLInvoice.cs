// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInvoice
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1022713000)]
  public class TLInvoice : TLObject
  {
    public override int Constructor => -1022713000;

    public int Flags { get; set; }

    public bool Test { get; set; }

    public bool NameRequested { get; set; }

    public bool PhoneRequested { get; set; }

    public bool EmailRequested { get; set; }

    public bool ShippingAddressRequested { get; set; }

    public bool Flexible { get; set; }

    public string Currency { get; set; }

    public TLVector<TLLabeledPrice> Prices { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Test ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.NameRequested ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.PhoneRequested ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.EmailRequested ? this.Flags | 8 : this.Flags & -9;
      this.Flags = this.ShippingAddressRequested ? this.Flags | 16 : this.Flags & -17;
      this.Flags = this.Flexible ? this.Flags | 32 : this.Flags & -33;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Test = (this.Flags & 1) != 0;
      this.NameRequested = (this.Flags & 2) != 0;
      this.PhoneRequested = (this.Flags & 4) != 0;
      this.EmailRequested = (this.Flags & 8) != 0;
      this.ShippingAddressRequested = (this.Flags & 16) != 0;
      this.Flexible = (this.Flags & 32) != 0;
      this.Currency = StringUtil.Deserialize(br);
      this.Prices = ObjectUtils.DeserializeVector<TLLabeledPrice>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      StringUtil.Serialize(this.Currency, bw);
      ObjectUtils.SerializeObject((object) this.Prices, bw);
    }
  }
}
