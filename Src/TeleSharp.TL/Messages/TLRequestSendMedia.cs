// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestSendMedia
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-923703407)]
  public class TLRequestSendMedia : TLMethod
  {
    public override int Constructor => -923703407;

    public int Flags { get; set; }

    public bool Silent { get; set; }

    public bool Background { get; set; }

    public bool ClearDraft { get; set; }

    public TLAbsInputPeer Peer { get; set; }

    public int? ReplyToMsgId { get; set; }

    public TLAbsInputMedia Media { get; set; }

    public long RandomId { get; set; }

    public TLAbsReplyMarkup ReplyMarkup { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Silent ? this.Flags | 32 : this.Flags & -33;
      this.Flags = this.Background ? this.Flags | 64 : this.Flags & -65;
      this.Flags = this.ClearDraft ? this.Flags | 128 : this.Flags & -129;
      this.Flags = this.ReplyToMsgId.HasValue ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.ReplyMarkup != null ? this.Flags | 4 : this.Flags & -5;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Silent = (this.Flags & 32) != 0;
      this.Background = (this.Flags & 64) != 0;
      this.ClearDraft = (this.Flags & 128) != 0;
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.ReplyToMsgId = (this.Flags & 1) == 0 ? new int?() : new int?(br.ReadInt32());
      this.Media = (TLAbsInputMedia) ObjectUtils.DeserializeObject(br);
      this.RandomId = br.ReadInt64();
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
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      if ((this.Flags & 1) != 0)
        bw.Write(this.ReplyToMsgId.Value);
      ObjectUtils.SerializeObject((object) this.Media, bw);
      bw.Write(this.RandomId);
      if ((this.Flags & 4) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.ReplyMarkup, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
    }
  }
}
