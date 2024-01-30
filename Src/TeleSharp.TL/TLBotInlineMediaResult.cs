// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLBotInlineMediaResult
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(400266251)]
  public class TLBotInlineMediaResult : TLAbsBotInlineResult
  {
    public override int Constructor => 400266251;

    public int Flags { get; set; }

    public string Id { get; set; }

    public string Type { get; set; }

    public TLAbsPhoto Photo { get; set; }

    public TLAbsDocument Document { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public TLAbsBotInlineMessage SendMessage { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Photo != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Document != null ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Title != null ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.Description != null ? this.Flags | 8 : this.Flags & -9;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Id = StringUtil.Deserialize(br);
      this.Type = StringUtil.Deserialize(br);
      this.Photo = (this.Flags & 1) == 0 ? (TLAbsPhoto) null : (TLAbsPhoto) ObjectUtils.DeserializeObject(br);
      this.Document = (this.Flags & 2) == 0 ? (TLAbsDocument) null : (TLAbsDocument) ObjectUtils.DeserializeObject(br);
      this.Title = (this.Flags & 4) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Description = (this.Flags & 8) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.SendMessage = (TLAbsBotInlineMessage) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      StringUtil.Serialize(this.Id, bw);
      StringUtil.Serialize(this.Type, bw);
      if ((this.Flags & 1) != 0)
        ObjectUtils.SerializeObject((object) this.Photo, bw);
      if ((this.Flags & 2) != 0)
        ObjectUtils.SerializeObject((object) this.Document, bw);
      if ((this.Flags & 4) != 0)
        StringUtil.Serialize(this.Title, bw);
      if ((this.Flags & 8) != 0)
        StringUtil.Serialize(this.Description, bw);
      ObjectUtils.SerializeObject((object) this.SendMessage, bw);
    }
  }
}
