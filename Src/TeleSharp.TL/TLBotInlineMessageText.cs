// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLBotInlineMessageText
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1937807902)]
  public class TLBotInlineMessageText : TLAbsBotInlineMessage
  {
    public override int Constructor => -1937807902;

    public int Flags { get; set; }

    public bool NoWebpage { get; set; }

    public string Message { get; set; }

    public TLVector<TLAbsMessageEntity> Entities { get; set; }

    public TLAbsReplyMarkup ReplyMarkup { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.NoWebpage ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Entities != null ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.ReplyMarkup != null ? this.Flags | 4 : this.Flags & -5;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.NoWebpage = (this.Flags & 1) != 0;
      this.Message = StringUtil.Deserialize(br);
      this.Entities = (this.Flags & 2) == 0 ? (TLVector<TLAbsMessageEntity>) null : ObjectUtils.DeserializeVector<TLAbsMessageEntity>(br);
      if ((this.Flags & 4) != 0)
        this.ReplyMarkup = (TLAbsReplyMarkup) ObjectUtils.DeserializeObject(br);
      else
        this.ReplyMarkup = (TLAbsReplyMarkup) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      StringUtil.Serialize(this.Message, bw);
      if ((this.Flags & 2) != 0)
        ObjectUtils.SerializeObject((object) this.Entities, bw);
      if ((this.Flags & 4) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.ReplyMarkup, bw);
    }
  }
}
