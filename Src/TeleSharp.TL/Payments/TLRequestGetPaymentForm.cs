// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Payments.TLRequestGetPaymentForm
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Payments
{
  [TLObject(-1712285883)]
  public class TLRequestGetPaymentForm : TLMethod
  {
    public override int Constructor => -1712285883;

    public int MsgId { get; set; }

    public TLPaymentForm Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.MsgId = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.MsgId);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLPaymentForm) ObjectUtils.DeserializeObject(br);
    }
  }
}
