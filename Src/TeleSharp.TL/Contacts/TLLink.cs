// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Contacts.TLLink
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Contacts
{
  [TLObject(986597452)]
  public class TLLink : TLObject
  {
    public override int Constructor => 986597452;

    public TLAbsContactLink MyLink { get; set; }

    public TLAbsContactLink ForeignLink { get; set; }

    public TLAbsUser User { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.MyLink = (TLAbsContactLink) ObjectUtils.DeserializeObject(br);
      this.ForeignLink = (TLAbsContactLink) ObjectUtils.DeserializeObject(br);
      this.User = (TLAbsUser) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.MyLink, bw);
      ObjectUtils.SerializeObject((object) this.ForeignLink, bw);
      ObjectUtils.SerializeObject((object) this.User, bw);
    }
  }
}
