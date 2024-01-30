// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateUserStatus
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(469489699)]
  public class TLUpdateUserStatus : TLAbsUpdate
  {
    public override int Constructor => 469489699;

    public int UserId { get; set; }

    public TLAbsUserStatus Status { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = br.ReadInt32();
      this.Status = (TLAbsUserStatus) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.UserId);
      ObjectUtils.SerializeObject((object) this.Status, bw);
    }
  }
}
