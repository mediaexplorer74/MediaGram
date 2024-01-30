// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Contacts.TLRequestImportContacts
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Contacts
{
  [TLObject(-634342611)]
  public class TLRequestImportContacts : TLMethod
  {
    public override int Constructor => -634342611;

    public TLVector<TLInputPhoneContact> Contacts { get; set; }

    public bool Replace { get; set; }

    public TLImportedContacts Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Contacts = ObjectUtils.DeserializeVector<TLInputPhoneContact>(br);
      this.Replace = BoolUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Contacts, bw);
      BoolUtil.Serialize(this.Replace, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLImportedContacts) ObjectUtils.DeserializeObject(br);
    }
  }
}
