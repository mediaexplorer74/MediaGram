// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Auth.TLRequestCheckPhone
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Auth
{
  [TLObject(1877286395)]
  public class TLRequestCheckPhone : TLMethod
  {
    public override int Constructor => 1877286395;

    public string PhoneNumber { get; set; }

    public TLCheckedPhone Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PhoneNumber = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.PhoneNumber, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLCheckedPhone) ObjectUtils.DeserializeObject(br);
    }
  }
}
