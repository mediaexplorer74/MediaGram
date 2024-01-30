// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Contacts.TLRequestDeleteContact
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Contacts
{
  [TLObject(-1902823612)]
  public class TLRequestDeleteContact : TLMethod
  {
    public override int Constructor => -1902823612;

    public TLAbsInputUser Id { get; set; }

    public TLLink Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLLink) ObjectUtils.DeserializeObject(br);
    }
  }
}
