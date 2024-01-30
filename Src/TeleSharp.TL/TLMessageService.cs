// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLMessageService
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1642487306)]
  public class TLMessageService : TLAbsMessage
  {
    public override int Constructor => -1642487306;

    public int Flags { get; set; }

    public bool Out { get; set; }

    public bool Mentioned { get; set; }

    public bool MediaUnread { get; set; }

    public bool Silent { get; set; }

    public bool Post { get; set; }

    public int Id { get; set; }

    public int? FromId { get; set; }

    public TLAbsPeer ToId { get; set; }

    public int? ReplyToMsgId { get; set; }

    public int Date { get; set; }

    public TLAbsMessageAction Action { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Out ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Mentioned ? this.Flags | 16 : this.Flags & -17;
      this.Flags = this.MediaUnread ? this.Flags | 32 : this.Flags & -33;
      this.Flags = this.Silent ? this.Flags | 8192 : this.Flags & -8193;
      this.Flags = this.Post ? this.Flags | 16384 : this.Flags & -16385;
      this.Flags = this.FromId.HasValue ? this.Flags | 256 : this.Flags & -257;
      this.Flags = this.ReplyToMsgId.HasValue ? this.Flags | 8 : this.Flags & -9;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Out = (this.Flags & 2) != 0;
      this.Mentioned = (this.Flags & 16) != 0;
      this.MediaUnread = (this.Flags & 32) != 0;
      this.Silent = (this.Flags & 8192) != 0;
      this.Post = (this.Flags & 16384) != 0;
      this.Id = br.ReadInt32();
      this.FromId = (this.Flags & 256) == 0 ? new int?() : new int?(br.ReadInt32());
      this.ToId = (TLAbsPeer) ObjectUtils.DeserializeObject(br);
      this.ReplyToMsgId = (this.Flags & 8) == 0 ? new int?() : new int?(br.ReadInt32());
      this.Date = br.ReadInt32();
      this.Action = (TLAbsMessageAction) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Id);
      int? nullable;
      if ((this.Flags & 256) != 0)
      {
        BinaryWriter binaryWriter = bw;
        nullable = this.FromId;
        int num = nullable.Value;
        binaryWriter.Write(num);
      }
      ObjectUtils.SerializeObject((object) this.ToId, bw);
      if ((this.Flags & 8) != 0)
      {
        BinaryWriter binaryWriter = bw;
        nullable = this.ReplyToMsgId;
        int num = nullable.Value;
        binaryWriter.Write(num);
      }
      bw.Write(this.Date);
      ObjectUtils.SerializeObject((object) this.Action, bw);
    }
  }
}
