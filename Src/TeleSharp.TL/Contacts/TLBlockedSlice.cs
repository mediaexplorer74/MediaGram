// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Contacts.TLBlockedSlice
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Contacts
{
  [TLObject(-1878523231)]
  public class TLBlockedSlice : TLAbsBlocked
  {
    public override int Constructor => -1878523231;

    public int Count { get; set; }

    public TLVector<TLContactBlocked> Blocked { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Count = br.ReadInt32();
      this.Blocked = ObjectUtils.DeserializeVector<TLContactBlocked>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Count);
      ObjectUtils.SerializeObject((object) this.Blocked, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
