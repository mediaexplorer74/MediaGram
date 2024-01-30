// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Auth.TLRequestDropTempAuthKeys
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Auth
{
  [TLObject(-1907842680)]
  public class TLRequestDropTempAuthKeys : TLMethod
  {
    public override int Constructor => -1907842680;

    public TLVector<long> ExceptAuthKeys { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ExceptAuthKeys = ObjectUtils.DeserializeVector<long>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.ExceptAuthKeys, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = BoolUtil.Deserialize(br);
    }
  }
}
