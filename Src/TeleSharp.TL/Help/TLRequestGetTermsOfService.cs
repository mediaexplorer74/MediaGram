// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Help.TLRequestGetTermsOfService
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Help
{
  [TLObject(889286899)]
  public class TLRequestGetTermsOfService : TLMethod
  {
    public override int Constructor => 889286899;

    public TLTermsOfService Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLTermsOfService) ObjectUtils.DeserializeObject(br);
    }
  }
}
