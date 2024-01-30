// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Payments.TLRequestValidateRequestedInfo
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Payments
{
  [TLObject(1997180532)]
  public class TLRequestValidateRequestedInfo : TLMethod
  {
    public override int Constructor => 1997180532;

    public int Flags { get; set; }

    public bool Save { get; set; }

    public int MsgId { get; set; }

    public TLPaymentRequestedInfo Info { get; set; }

    public TLValidatedRequestedInfo Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Save ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Save = (this.Flags & 1) != 0;
      this.MsgId = br.ReadInt32();
      this.Info = (TLPaymentRequestedInfo) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.MsgId);
      ObjectUtils.SerializeObject((object) this.Info, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLValidatedRequestedInfo) ObjectUtils.DeserializeObject(br);
    }
  }
}
