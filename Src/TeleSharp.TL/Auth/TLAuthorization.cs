// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Auth.TLAuthorization
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Auth
{
  [TLObject(-855308010)]
  public class TLAuthorization : TLObject
  {
    public override int Constructor => -855308010;

    public int Flags { get; set; }

    public int? TmpSessions { get; set; }

    public TLAbsUser User { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.TmpSessions.HasValue ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.TmpSessions = (this.Flags & 1) == 0 ? new int?() : new int?(br.ReadInt32());
      this.User = (TLAbsUser) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      if ((this.Flags & 1) != 0)
        bw.Write(this.TmpSessions.Value);
      ObjectUtils.SerializeObject((object) this.User, bw);
    }
  }
}
