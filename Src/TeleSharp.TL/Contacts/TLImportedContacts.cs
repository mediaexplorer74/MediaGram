// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Contacts.TLImportedContacts
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Contacts
{
  [TLObject(-1387117803)]
  public class TLImportedContacts : TLObject
  {
    public override int Constructor => -1387117803;

    public TLVector<TLImportedContact> Imported { get; set; }

    public TLVector<long> RetryContacts { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Imported = ObjectUtils.DeserializeVector<TLImportedContact>(br);
      this.RetryContacts = ObjectUtils.DeserializeVector<long>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Imported, bw);
      ObjectUtils.SerializeObject((object) this.RetryContacts, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
