// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Payments.TLPaymentForm
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Payments
{
  [TLObject(1062645411)]
  public class TLPaymentForm : TLObject
  {
    public override int Constructor => 1062645411;

    public int Flags { get; set; }

    public bool CanSaveCredentials { get; set; }

    public bool PasswordMissing { get; set; }

    public int BotId { get; set; }

    public TLInvoice Invoice { get; set; }

    public int ProviderId { get; set; }

    public string Url { get; set; }

    public string NativeProvider { get; set; }

    public TLDataJSON NativeParams { get; set; }

    public TLPaymentRequestedInfo SavedInfo { get; set; }

    public TLPaymentSavedCredentialsCard SavedCredentials { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.CanSaveCredentials ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.PasswordMissing ? this.Flags | 8 : this.Flags & -9;
      this.Flags = this.NativeProvider != null ? this.Flags | 16 : this.Flags & -17;
      this.Flags = this.NativeParams != null ? this.Flags | 16 : this.Flags & -17;
      this.Flags = this.SavedInfo != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.SavedCredentials != null ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.CanSaveCredentials = (this.Flags & 4) != 0;
      this.PasswordMissing = (this.Flags & 8) != 0;
      this.BotId = br.ReadInt32();
      this.Invoice = (TLInvoice) ObjectUtils.DeserializeObject(br);
      this.ProviderId = br.ReadInt32();
      this.Url = StringUtil.Deserialize(br);
      this.NativeProvider = (this.Flags & 16) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.NativeParams = (this.Flags & 16) == 0 ? (TLDataJSON) null : (TLDataJSON) ObjectUtils.DeserializeObject(br);
      this.SavedInfo = (this.Flags & 1) == 0 ? (TLPaymentRequestedInfo) null : (TLPaymentRequestedInfo) ObjectUtils.DeserializeObject(br);
      this.SavedCredentials = (this.Flags & 2) == 0 ? (TLPaymentSavedCredentialsCard) null : (TLPaymentSavedCredentialsCard) ObjectUtils.DeserializeObject(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.BotId);
      ObjectUtils.SerializeObject((object) this.Invoice, bw);
      bw.Write(this.ProviderId);
      StringUtil.Serialize(this.Url, bw);
      if ((this.Flags & 16) != 0)
        StringUtil.Serialize(this.NativeProvider, bw);
      if ((this.Flags & 16) != 0)
        ObjectUtils.SerializeObject((object) this.NativeParams, bw);
      if ((this.Flags & 1) != 0)
        ObjectUtils.SerializeObject((object) this.SavedInfo, bw);
      if ((this.Flags & 2) != 0)
        ObjectUtils.SerializeObject((object) this.SavedCredentials, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
