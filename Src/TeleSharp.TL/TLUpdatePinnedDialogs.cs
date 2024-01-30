// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdatePinnedDialogs
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-657787251)]
  public class TLUpdatePinnedDialogs : TLAbsUpdate
  {
    public override int Constructor => -657787251;

    public int Flags { get; set; }

    public TLVector<TLAbsPeer> Order { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Order != null ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      if ((this.Flags & 1) != 0)
        this.Order = ObjectUtils.DeserializeVector<TLAbsPeer>(br);
      else
        this.Order = (TLVector<TLAbsPeer>) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      if ((this.Flags & 1) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.Order, bw);
    }
  }
}
