// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Payments.TLPaymentVerficationNeeded
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Payments
{
  [TLObject(1800845601)]
  public class TLPaymentVerficationNeeded : TLAbsPaymentResult
  {
    public override int Constructor => 1800845601;

    public string Url { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Url = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Url, bw);
    }
  }
}
