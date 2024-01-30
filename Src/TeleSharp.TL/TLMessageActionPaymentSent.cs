// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLMessageActionPaymentSent
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1080663248)]
  public class TLMessageActionPaymentSent : TLAbsMessageAction
  {
    public override int Constructor => 1080663248;

    public string Currency { get; set; }

    public long TotalAmount { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Currency = StringUtil.Deserialize(br);
      this.TotalAmount = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Currency, bw);
      bw.Write(this.TotalAmount);
    }
  }
}
