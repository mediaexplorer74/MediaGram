// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Account.TLRequestGetPasswordSettings
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Account
{
  [TLObject(-1131605573)]
  public class TLRequestGetPasswordSettings : TLMethod
  {
    public override int Constructor => -1131605573;

    public byte[] CurrentPasswordHash { get; set; }

    public TLPasswordSettings Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.CurrentPasswordHash = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BytesUtil.Serialize(this.CurrentPasswordHash, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLPasswordSettings) ObjectUtils.DeserializeObject(br);
    }
  }
}
