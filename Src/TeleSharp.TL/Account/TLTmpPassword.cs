// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Account.TLTmpPassword
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Account
{
  [TLObject(-614138572)]
  public class TLTmpPassword : TLObject
  {
    public override int Constructor => -614138572;

    public byte[] TmpPassword { get; set; }

    public int ValidUntil { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.TmpPassword = BytesUtil.Deserialize(br);
      this.ValidUntil = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BytesUtil.Serialize(this.TmpPassword, bw);
      bw.Write(this.ValidUntil);
    }
  }
}
