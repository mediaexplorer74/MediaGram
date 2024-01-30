// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLContactStatus
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-748155807)]
  public class TLContactStatus : TLObject
  {
    public override int Constructor => -748155807;

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
