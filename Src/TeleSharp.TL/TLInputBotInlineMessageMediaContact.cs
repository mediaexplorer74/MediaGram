// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputBotInlineMessageMediaContact
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(766443943)]
  public class TLInputBotInlineMessageMediaContact : TLAbsInputBotInlineMessage
  {
    public override int Constructor => 766443943;

    public int Flags { get; set; }

    public string PhoneNumber { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public TLAbsReplyMarkup ReplyMarkup { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.ReplyMarkup != null ? this.Flags | 4 : this.Flags & -5;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.PhoneNumber = StringUtil.Deserialize(br);
      this.FirstName = StringUtil.Deserialize(br);
      this.LastName = StringUtil.Deserialize(br);
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
      StringUtil.Serialize(this.PhoneNumber, bw);
      StringUtil.Serialize(this.FirstName, bw);
      StringUtil.Serialize(this.LastName, bw);
      if ((this.Flags & 4) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.ReplyMarkup, bw);
    }
  }
}
