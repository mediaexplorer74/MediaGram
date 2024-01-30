// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Contacts.TLRequestGetContacts
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Contacts
{
  [TLObject(583445000)]
  public class TLRequestGetContacts : TLMethod
  {
    public override int Constructor => 583445000;

    public string Hash { get; set; }

    public TLAbsContacts Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Hash = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Hash, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsContacts) ObjectUtils.DeserializeObject(br);
    }
  }
}
