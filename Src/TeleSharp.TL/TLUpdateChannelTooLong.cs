// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateChannelTooLong
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-352032773)]
  public class TLUpdateChannelTooLong : TLAbsUpdate
  {
    public override int Constructor => -352032773;

    public int Flags { get; set; }

    public int ChannelId { get; set; }

    public int? Pts { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Pts.HasValue ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.ChannelId = br.ReadInt32();
      if ((this.Flags & 1) != 0)
        this.Pts = new int?(br.ReadInt32());
      else
        this.Pts = new int?();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.ChannelId);
      if ((this.Flags & 1) == 0)
        return;
      bw.Write(this.Pts.Value);
    }
  }
}
