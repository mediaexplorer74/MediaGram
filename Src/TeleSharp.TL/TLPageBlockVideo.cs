// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLPageBlockVideo
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-640214938)]
  public class TLPageBlockVideo : TLAbsPageBlock
  {
    public override int Constructor => -640214938;

    public int Flags { get; set; }

    public bool Autoplay { get; set; }

    public bool Loop { get; set; }

    public long VideoId { get; set; }

    public TLAbsRichText Caption { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Autoplay ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Loop ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Autoplay = (this.Flags & 1) != 0;
      this.Loop = (this.Flags & 2) != 0;
      this.VideoId = br.ReadInt64();
      this.Caption = (TLAbsRichText) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.VideoId);
      ObjectUtils.SerializeObject((object) this.Caption, bw);
    }
  }
}
