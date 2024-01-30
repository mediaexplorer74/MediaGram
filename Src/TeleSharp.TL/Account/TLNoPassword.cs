// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Account.TLNoPassword
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Account
{
  [TLObject(-1764049896)]
  public class TLNoPassword : TLAbsPassword
  {
    public override int Constructor => -1764049896;

    public byte[] NewSalt { get; set; }

    public string EmailUnconfirmedPattern { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.NewSalt = BytesUtil.Deserialize(br);
      this.EmailUnconfirmedPattern = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BytesUtil.Serialize(this.NewSalt, bw);
      StringUtil.Serialize(this.EmailUnconfirmedPattern, bw);
    }
  }
}
