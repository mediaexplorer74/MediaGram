// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputPhoneContact
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-208488460)]
  public class TLInputPhoneContact : TLObject
  {
    public override int Constructor => -208488460;

    public long ClientId { get; set; }

    public string Phone { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ClientId = br.ReadInt64();
      this.Phone = StringUtil.Deserialize(br);
      this.FirstName = StringUtil.Deserialize(br);
      this.LastName = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ClientId);
      StringUtil.Serialize(this.Phone, bw);
      StringUtil.Serialize(this.FirstName, bw);
      StringUtil.Serialize(this.LastName, bw);
    }
  }
}
