// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLDraftMessage
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-40996577)]
  public class TLDraftMessage : TLAbsDraftMessage
  {
    public override int Constructor => -40996577;

    public int Flags { get; set; }

    public bool NoWebpage { get; set; }

    public int? ReplyToMsgId { get; set; }

    public string Message { get; set; }

    public TLVector<TLAbsMessageEntity> Entities { get; set; }

    public int Date { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.NoWebpage ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.ReplyToMsgId.HasValue ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Entities != null ? this.Flags | 8 : this.Flags & -9;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.NoWebpage = (this.Flags & 2) != 0;
      this.ReplyToMsgId = (this.Flags & 1) == 0 ? new int?() : new int?(br.ReadInt32());
      this.Message = StringUtil.Deserialize(br);
      this.Entities = (this.Flags & 8) == 0 ? (TLVector<TLAbsMessageEntity>) null : ObjectUtils.DeserializeVector<TLAbsMessageEntity>(br);
      this.Date = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      if ((this.Flags & 1) != 0)
        bw.Write(this.ReplyToMsgId.Value);
      StringUtil.Serialize(this.Message, bw);
      if ((this.Flags & 8) != 0)
        ObjectUtils.SerializeObject((object) this.Entities, bw);
      bw.Write(this.Date);
    }
  }
}
