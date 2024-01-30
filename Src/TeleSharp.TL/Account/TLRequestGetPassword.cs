// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Account.TLRequestGetPassword
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Account
{
  [TLObject(1418342645)]
  public class TLRequestGetPassword : TLMethod
  {
    public override int Constructor => 1418342645;

    public TLAbsPassword Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsPassword) ObjectUtils.DeserializeObject(br);
    }
  }
}
