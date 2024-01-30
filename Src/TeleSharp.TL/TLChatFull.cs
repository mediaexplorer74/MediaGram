// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLChatFull
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(771925524)]
  public class TLChatFull : TLAbsChatFull
  {
    public override int Constructor => 771925524;

    public int Id { get; set; }

    public TLAbsChatParticipants Participants { get; set; }

    public TLAbsPhoto ChatPhoto { get; set; }

    public TLAbsPeerNotifySettings NotifySettings { get; set; }

    public TLAbsExportedChatInvite ExportedInvite { get; set; }

    public TLVector<TLBotInfo> BotInfo { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt32();
      this.Participants = (TLAbsChatParticipants) ObjectUtils.DeserializeObject(br);
      this.ChatPhoto = (TLAbsPhoto) ObjectUtils.DeserializeObject(br);
      this.NotifySettings = (TLAbsPeerNotifySettings) ObjectUtils.DeserializeObject(br);
      this.ExportedInvite = (TLAbsExportedChatInvite) ObjectUtils.DeserializeObject(br);
      this.BotInfo = ObjectUtils.DeserializeVector<TLBotInfo>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      ObjectUtils.SerializeObject((object) this.Participants, bw);
      ObjectUtils.SerializeObject((object) this.ChatPhoto, bw);
      ObjectUtils.SerializeObject((object) this.NotifySettings, bw);
      ObjectUtils.SerializeObject((object) this.ExportedInvite, bw);
      ObjectUtils.SerializeObject((object) this.BotInfo, bw);
    }
  }
}
