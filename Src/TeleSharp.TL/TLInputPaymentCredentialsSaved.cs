// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputPaymentCredentialsSaved
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1056001329)]
  public class TLInputPaymentCredentialsSaved : TLAbsInputPaymentCredentials
  {
    public override int Constructor => -1056001329;

    public string Id { get; set; }

    public byte[] TmpPassword { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = StringUtil.Deserialize(br);
      this.TmpPassword = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Id, bw);
      BytesUtil.Serialize(this.TmpPassword, bw);
    }
  }
}
