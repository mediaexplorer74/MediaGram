// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Account.TLRequestGetTmpPassword
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Account
{
  [TLObject(1250046590)]
  public class TLRequestGetTmpPassword : TLMethod
  {
    public override int Constructor => 1250046590;

    public byte[] PasswordHash { get; set; }

    public int Period { get; set; }

    public TLTmpPassword Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PasswordHash = BytesUtil.Deserialize(br);
      this.Period = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BytesUtil.Serialize(this.PasswordHash, bw);
      bw.Write(this.Period);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLTmpPassword) ObjectUtils.DeserializeObject(br);
    }
  }
}
