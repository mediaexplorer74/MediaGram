// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLDocumentAttributeAudio
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1739392570)]
  public class TLDocumentAttributeAudio : TLAbsDocumentAttribute
  {
    public override int Constructor => -1739392570;

    public int Flags { get; set; }

    public bool Voice { get; set; }

    public int Duration { get; set; }

    public string Title { get; set; }

    public string Performer { get; set; }

    public byte[] Waveform { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Voice ? this.Flags | 1024 : this.Flags & -1025;
      this.Flags = this.Title != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Performer != null ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Waveform != null ? this.Flags | 4 : this.Flags & -5;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Voice = (this.Flags & 1024) != 0;
      this.Duration = br.ReadInt32();
      this.Title = (this.Flags & 1) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Performer = (this.Flags & 2) == 0 ? (string) null : StringUtil.Deserialize(br);
      if ((this.Flags & 4) != 0)
        this.Waveform = BytesUtil.Deserialize(br);
      else
        this.Waveform = (byte[]) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Duration);
      if ((this.Flags & 1) != 0)
        StringUtil.Serialize(this.Title, bw);
      if ((this.Flags & 2) != 0)
        StringUtil.Serialize(this.Performer, bw);
      if ((this.Flags & 4) == 0)
        return;
      BytesUtil.Serialize(this.Waveform, bw);
    }
  }
}
