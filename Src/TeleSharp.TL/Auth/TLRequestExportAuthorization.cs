// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Auth.TLRequestExportAuthorization
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Auth
{
  [TLObject(-440401971)]
  public class TLRequestExportAuthorization : TLMethod
  {
    public override int Constructor => -440401971;

    public int DcId { get; set; }

    public TLExportedAuthorization Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.DcId = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.DcId);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLExportedAuthorization) ObjectUtils.DeserializeObject(br);
    }
  }
}
