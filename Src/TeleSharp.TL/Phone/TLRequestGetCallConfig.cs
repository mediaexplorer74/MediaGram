// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Phone.TLRequestGetCallConfig
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Phone
{
  [TLObject(1430593449)]
  public class TLRequestGetCallConfig : TLMethod
  {
    public override int Constructor => 1430593449;

    public TLDataJSON Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLDataJSON) ObjectUtils.DeserializeObject(br);
    }
  }
}
