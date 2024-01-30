// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Payments.TLValidatedRequestedInfo
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Payments
{
  [TLObject(-784000893)]
  public class TLValidatedRequestedInfo : TLObject
  {
    public override int Constructor => -784000893;

    public int Flags { get; set; }

    public string Id { get; set; }

    public TLVector<TLShippingOption> ShippingOptions { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Id != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.ShippingOptions != null ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Id = (this.Flags & 1) == 0 ? (string) null : StringUtil.Deserialize(br);
      if ((this.Flags & 2) != 0)
        this.ShippingOptions = ObjectUtils.DeserializeVector<TLShippingOption>(br);
      else
        this.ShippingOptions = (TLVector<TLShippingOption>) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      if ((this.Flags & 1) != 0)
        StringUtil.Serialize(this.Id, bw);
      if ((this.Flags & 2) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.ShippingOptions, bw);
    }
  }
}
