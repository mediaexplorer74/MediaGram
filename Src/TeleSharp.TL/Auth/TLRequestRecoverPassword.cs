// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Auth.TLRequestRecoverPassword
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Auth
{
  [TLObject(1319464594)]
  public class TLRequestRecoverPassword : TLMethod
  {
    public override int Constructor => 1319464594;

    public string Code { get; set; }

    public TLAuthorization Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Code = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Code, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAuthorization) ObjectUtils.DeserializeObject(br);
    }
  }
}
