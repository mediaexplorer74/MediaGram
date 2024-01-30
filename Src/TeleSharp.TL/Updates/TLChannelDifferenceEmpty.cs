// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Updates.TLChannelDifferenceEmpty
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Updates
{
  [TLObject(1041346555)]
  public class TLChannelDifferenceEmpty : TLAbsChannelDifference
  {
    public override int Constructor => 1041346555;

    public int Flags { get; set; }

    public bool Final { get; set; }

    public int Pts { get; set; }

    public int? Timeout { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Final ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Timeout.HasValue ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Final = (this.Flags & 1) != 0;
      this.Pts = br.ReadInt32();
      if ((this.Flags & 2) != 0)
        this.Timeout = new int?(br.ReadInt32());
      else
        this.Timeout = new int?();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Pts);
      if ((this.Flags & 2) == 0)
        return;
      bw.Write(this.Timeout.Value);
    }
  }
}
