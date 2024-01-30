// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLPaymentCharge
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-368917890)]
  public class TLPaymentCharge : TLObject
  {
    public override int Constructor => -368917890;

    public string Id { get; set; }

    public string ProviderChargeId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = StringUtil.Deserialize(br);
      this.ProviderChargeId = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Id, bw);
      StringUtil.Serialize(this.ProviderChargeId, bw);
    }
  }
}
