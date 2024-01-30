// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestEditInlineBotMessage
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(319564933)]
  public class TLRequestEditInlineBotMessage : TLMethod
  {
    public override int Constructor => 319564933;

    public int Flags { get; set; }

    public bool NoWebpage { get; set; }

    public TLInputBotInlineMessageID Id { get; set; }

    public string Message { get; set; }

    public TLAbsReplyMarkup ReplyMarkup { get; set; }

    public TLVector<TLAbsMessageEntity> Entities { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.NoWebpage ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Message != null ? this.Flags | 2048 : this.Flags & -2049;
      this.Flags = this.ReplyMarkup != null ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.Entities != null ? this.Flags | 8 : this.Flags & -9;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.NoWebpage = (this.Flags & 2) != 0;
      this.Id = (TLInputBotInlineMessageID) ObjectUtils.DeserializeObject(br);
      this.Message = (this.Flags & 2048) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.ReplyMarkup = (this.Flags & 4) == 0 ? (TLAbsReplyMarkup) null : (TLAbsReplyMarkup) ObjectUtils.DeserializeObject(br);
      if ((this.Flags & 8) != 0)
        this.Entities = ObjectUtils.DeserializeVector<TLAbsMessageEntity>(br);
      else
        this.Entities = (TLVector<TLAbsMessageEntity>) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Id, bw);
      if ((this.Flags & 2048) != 0)
        StringUtil.Serialize(this.Message, bw);
      if ((this.Flags & 4) != 0)
        ObjectUtils.SerializeObject((object) this.ReplyMarkup, bw);
      if ((this.Flags & 8) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.Entities, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = BoolUtil.Deserialize(br);
    }
  }
}
