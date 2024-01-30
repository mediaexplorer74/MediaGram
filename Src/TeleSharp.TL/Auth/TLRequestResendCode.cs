// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Auth.TLRequestResendCode
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Auth
{
  [TLObject(1056025023)]
  public class TLRequestResendCode : TLMethod
  {
    public override int Constructor => 1056025023;

    public string PhoneNumber { get; set; }

    public string PhoneCodeHash { get; set; }

    public TLSentCode Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PhoneNumber = StringUtil.Deserialize(br);
      this.PhoneCodeHash = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.PhoneNumber, bw);
      StringUtil.Serialize(this.PhoneCodeHash, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLSentCode) ObjectUtils.DeserializeObject(br);
    }
  }
}
