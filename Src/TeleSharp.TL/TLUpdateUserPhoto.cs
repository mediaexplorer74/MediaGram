// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateUserPhoto
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1791935732)]
  public class TLUpdateUserPhoto : TLAbsUpdate
  {
    public override int Constructor => -1791935732;

    public int UserId { get; set; }

    public int Date { get; set; }

    public TLAbsUserProfilePhoto Photo { get; set; }

    public bool Previous { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = br.ReadInt32();
      this.Date = br.ReadInt32();
      this.Photo = (TLAbsUserProfilePhoto) ObjectUtils.DeserializeObject(br);
      this.Previous = BoolUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.UserId);
      bw.Write(this.Date);
      ObjectUtils.SerializeObject((object) this.Photo, bw);
      BoolUtil.Serialize(this.Previous, bw);
    }
  }
}
