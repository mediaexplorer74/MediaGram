// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Help.TLRequestGetAppUpdate
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Help
{
  [TLObject(-1372724842)]
  public class TLRequestGetAppUpdate : TLMethod
  {
    public override int Constructor => -1372724842;

    public TLAbsAppUpdate Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsAppUpdate) ObjectUtils.DeserializeObject(br);
    }
  }
}
