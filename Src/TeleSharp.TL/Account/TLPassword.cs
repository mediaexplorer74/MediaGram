// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Account.TLPassword
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Account
{
  [TLObject(2081952796)]
  public class TLPassword : TLAbsPassword
  {
    public override int Constructor => 2081952796;

    public byte[] CurrentSalt { get; set; }

    public byte[] NewSalt { get; set; }

    public string Hint { get; set; }

    public bool HasRecovery { get; set; }

    public string EmailUnconfirmedPattern { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.CurrentSalt = BytesUtil.Deserialize(br);
      this.NewSalt = BytesUtil.Deserialize(br);
      this.Hint = StringUtil.Deserialize(br);
      this.HasRecovery = BoolUtil.Deserialize(br);
      this.EmailUnconfirmedPattern = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BytesUtil.Serialize(this.CurrentSalt, bw);
      BytesUtil.Serialize(this.NewSalt, bw);
      StringUtil.Serialize(this.Hint, bw);
      BoolUtil.Serialize(this.HasRecovery, bw);
      StringUtil.Serialize(this.EmailUnconfirmedPattern, bw);
    }
  }
}
