// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateShortSentMessage
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(301019932)]
  public class TLUpdateShortSentMessage : TLAbsUpdates
  {
    public override int Constructor => 301019932;

    public int Flags { get; set; }

    public bool Out { get; set; }

    public int Id { get; set; }

    public int Pts { get; set; }

    public int PtsCount { get; set; }

    public int Date { get; set; }

    public TLAbsMessageMedia Media { get; set; }

    public TLVector<TLAbsMessageEntity> Entities { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Out ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Media != null ? this.Flags | 512 : this.Flags & -513;
      this.Flags = this.Entities != null ? this.Flags | 128 : this.Flags & -129;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Out = (this.Flags & 2) != 0;
      this.Id = br.ReadInt32();
      this.Pts = br.ReadInt32();
      this.PtsCount = br.ReadInt32();
      this.Date = br.ReadInt32();
      this.Media = (this.Flags & 512) == 0 ? (TLAbsMessageMedia) null : (TLAbsMessageMedia) ObjectUtils.DeserializeObject(br);
      if ((this.Flags & 128) != 0)
        this.Entities = ObjectUtils.DeserializeVector<TLAbsMessageEntity>(br);
      else
        this.Entities = (TLVector<TLAbsMessageEntity>) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Id);
      bw.Write(this.Pts);
      bw.Write(this.PtsCount);
      bw.Write(this.Date);
      if ((this.Flags & 512) != 0)
        ObjectUtils.SerializeObject((object) this.Media, bw);
      if ((this.Flags & 128) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.Entities, bw);
    }
  }
}
