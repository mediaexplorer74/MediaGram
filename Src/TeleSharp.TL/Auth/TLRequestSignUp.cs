// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Auth.TLRequestSignUp
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Auth
{
  [TLObject(453408308)]
  public class TLRequestSignUp : TLMethod
  {
    public override int Constructor => 453408308;

    public string PhoneNumber { get; set; }

    public string PhoneCodeHash { get; set; }

    public string PhoneCode { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public TLAuthorization Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PhoneNumber = StringUtil.Deserialize(br);
      this.PhoneCodeHash = StringUtil.Deserialize(br);
      this.PhoneCode = StringUtil.Deserialize(br);
      this.FirstName = StringUtil.Deserialize(br);
      this.LastName = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.PhoneNumber, bw);
      StringUtil.Serialize(this.PhoneCodeHash, bw);
      StringUtil.Serialize(this.PhoneCode, bw);
      StringUtil.Serialize(this.FirstName, bw);
      StringUtil.Serialize(this.LastName, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAuthorization) ObjectUtils.DeserializeObject(br);
    }
  }
}
