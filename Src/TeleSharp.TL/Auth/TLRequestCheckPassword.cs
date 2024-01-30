// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Auth.TLRequestCheckPassword
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Auth
{
  [TLObject(174260510)]
  public class TLRequestCheckPassword : TLMethod
  {
    public override int Constructor => 174260510;

    public byte[] PasswordHash { get; set; }

    public TLAuthorization Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PasswordHash = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BytesUtil.Serialize(this.PasswordHash, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAuthorization) ObjectUtils.DeserializeObject(br);
    }
  }
}
