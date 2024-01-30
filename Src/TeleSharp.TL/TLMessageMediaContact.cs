// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLMessageMediaContact
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1585262393)]
  public class TLMessageMediaContact : TLAbsMessageMedia
  {
    public override int Constructor => 1585262393;

    public string PhoneNumber { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int UserId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PhoneNumber = StringUtil.Deserialize(br);
      this.FirstName = StringUtil.Deserialize(br);
      this.LastName = StringUtil.Deserialize(br);
      this.UserId = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.PhoneNumber, bw);
      StringUtil.Serialize(this.FirstName, bw);
      StringUtil.Serialize(this.LastName, bw);
      bw.Write(this.UserId);
    }
  }
}
