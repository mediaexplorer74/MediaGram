// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Account.TLPasswordInputSettings
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Account
{
  [TLObject(-2037289493)]
  public class TLPasswordInputSettings : TLObject
  {
    public override int Constructor => -2037289493;

    public int Flags { get; set; }

    public byte[] NewSalt { get; set; }

    public byte[] NewPasswordHash { get; set; }

    public string Hint { get; set; }

    public string Email { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.NewSalt != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.NewPasswordHash != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Hint != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Email != null ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.NewSalt = (this.Flags & 1) == 0 ? (byte[]) null : BytesUtil.Deserialize(br);
      this.NewPasswordHash = (this.Flags & 1) == 0 ? (byte[]) null : BytesUtil.Deserialize(br);
      this.Hint = (this.Flags & 1) == 0 ? (string) null : StringUtil.Deserialize(br);
      if ((this.Flags & 2) != 0)
        this.Email = StringUtil.Deserialize(br);
      else
        this.Email = (string) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      if ((this.Flags & 1) != 0)
        BytesUtil.Serialize(this.NewSalt, bw);
      if ((this.Flags & 1) != 0)
        BytesUtil.Serialize(this.NewPasswordHash, bw);
      if ((this.Flags & 1) != 0)
        StringUtil.Serialize(this.Hint, bw);
      if ((this.Flags & 2) == 0)
        return;
      StringUtil.Serialize(this.Email, bw);
    }
  }
}
