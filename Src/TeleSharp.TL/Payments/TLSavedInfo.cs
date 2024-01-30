// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Payments.TLSavedInfo
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Payments
{
  [TLObject(-74456004)]
  public class TLSavedInfo : TLObject
  {
    public override int Constructor => -74456004;

    public int Flags { get; set; }

    public bool HasSavedCredentials { get; set; }

    public TLPaymentRequestedInfo SavedInfo { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.HasSavedCredentials ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.SavedInfo != null ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.HasSavedCredentials = (this.Flags & 2) != 0;
      if ((this.Flags & 1) != 0)
        this.SavedInfo = (TLPaymentRequestedInfo) ObjectUtils.DeserializeObject(br);
      else
        this.SavedInfo = (TLPaymentRequestedInfo) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      if ((this.Flags & 1) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.SavedInfo, bw);
    }
  }
}
