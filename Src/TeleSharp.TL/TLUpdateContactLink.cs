// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateContactLink
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1657903163)]
  public class TLUpdateContactLink : TLAbsUpdate
  {
    public override int Constructor => -1657903163;

    public int UserId { get; set; }

    public TLAbsContactLink MyLink { get; set; }

    public TLAbsContactLink ForeignLink { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = br.ReadInt32();
      this.MyLink = (TLAbsContactLink) ObjectUtils.DeserializeObject(br);
      this.ForeignLink = (TLAbsContactLink) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.UserId);
      ObjectUtils.SerializeObject((object) this.MyLink, bw);
      ObjectUtils.SerializeObject((object) this.ForeignLink, bw);
    }
  }
}
