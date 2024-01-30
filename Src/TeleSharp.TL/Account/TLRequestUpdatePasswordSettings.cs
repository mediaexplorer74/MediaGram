// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Account.TLRequestUpdatePasswordSettings
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Account
{
  [TLObject(-92517498)]
  public class TLRequestUpdatePasswordSettings : TLMethod
  {
    public override int Constructor => -92517498;

    public byte[] CurrentPasswordHash { get; set; }

    public TLPasswordInputSettings NewSettings { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.CurrentPasswordHash = BytesUtil.Deserialize(br);
      this.NewSettings = (TLPasswordInputSettings) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BytesUtil.Serialize(this.CurrentPasswordHash, bw);
      ObjectUtils.SerializeObject((object) this.NewSettings, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = BoolUtil.Deserialize(br);
    }
  }
}
