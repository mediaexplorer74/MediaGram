// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLPeerNotifySettings
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1697798976)]
  public class TLPeerNotifySettings : TLAbsPeerNotifySettings
  {
    public override int Constructor => -1697798976;

    public int Flags { get; set; }

    public bool ShowPreviews { get; set; }

    public bool Silent { get; set; }

    public int MuteUntil { get; set; }

    public string Sound { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.ShowPreviews ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Silent ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.ShowPreviews = (this.Flags & 1) != 0;
      this.Silent = (this.Flags & 2) != 0;
      this.MuteUntil = br.ReadInt32();
      this.Sound = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.MuteUntil);
      StringUtil.Serialize(this.Sound, bw);
    }
  }
}
