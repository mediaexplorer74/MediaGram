// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLPaymentRequestedInfo
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1868808300)]
  public class TLPaymentRequestedInfo : TLObject
  {
    public override int Constructor => -1868808300;

    public int Flags { get; set; }

    public string Name { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public TLPostAddress ShippingAddress { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Name != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Phone != null ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Email != null ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.ShippingAddress != null ? this.Flags | 8 : this.Flags & -9;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Name = (this.Flags & 1) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Phone = (this.Flags & 2) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Email = (this.Flags & 4) == 0 ? (string) null : StringUtil.Deserialize(br);
      if ((this.Flags & 8) != 0)
        this.ShippingAddress = (TLPostAddress) ObjectUtils.DeserializeObject(br);
      else
        this.ShippingAddress = (TLPostAddress) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      if ((this.Flags & 1) != 0)
        StringUtil.Serialize(this.Name, bw);
      if ((this.Flags & 2) != 0)
        StringUtil.Serialize(this.Phone, bw);
      if ((this.Flags & 4) != 0)
        StringUtil.Serialize(this.Email, bw);
      if ((this.Flags & 8) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.ShippingAddress, bw);
    }
  }
}
