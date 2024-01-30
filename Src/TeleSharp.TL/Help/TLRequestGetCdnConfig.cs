// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Help.TLRequestGetCdnConfig
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Help
{
  [TLObject(1375900482)]
  public class TLRequestGetCdnConfig : TLMethod
  {
    public override int Constructor => 1375900482;

    public TLCdnConfig Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLCdnConfig) ObjectUtils.DeserializeObject(br);
    }
  }
}
