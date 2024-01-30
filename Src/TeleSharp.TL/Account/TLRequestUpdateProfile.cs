// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Account.TLRequestUpdateProfile
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Account
{
  [TLObject(2018596725)]
  public class TLRequestUpdateProfile : TLMethod
  {
    public override int Constructor => 2018596725;

    public int Flags { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string About { get; set; }

    public TLAbsUser Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.FirstName != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.LastName != null ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.About != null ? this.Flags | 4 : this.Flags & -5;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.FirstName = (this.Flags & 1) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.LastName = (this.Flags & 2) == 0 ? (string) null : StringUtil.Deserialize(br);
      if ((this.Flags & 4) != 0)
        this.About = StringUtil.Deserialize(br);
      else
        this.About = (string) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      if ((this.Flags & 1) != 0)
        StringUtil.Serialize(this.FirstName, bw);
      if ((this.Flags & 2) != 0)
        StringUtil.Serialize(this.LastName, bw);
      if ((this.Flags & 4) == 0)
        return;
      StringUtil.Serialize(this.About, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsUser) ObjectUtils.DeserializeObject(br);
    }
  }
}
