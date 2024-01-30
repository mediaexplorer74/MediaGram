// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLChatParticipantsForbidden
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-57668565)]
  public class TLChatParticipantsForbidden : TLAbsChatParticipants
  {
    public override int Constructor => -57668565;

    public int Flags { get; set; }

    public int ChatId { get; set; }

    public TLAbsChatParticipant SelfParticipant { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.SelfParticipant != null ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.ChatId = br.ReadInt32();
      if ((this.Flags & 1) != 0)
        this.SelfParticipant = (TLAbsChatParticipant) ObjectUtils.DeserializeObject(br);
      else
        this.SelfParticipant = (TLAbsChatParticipant) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.ChatId);
      if ((this.Flags & 1) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.SelfParticipant, bw);
    }
  }
}
