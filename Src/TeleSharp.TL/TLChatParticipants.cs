// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLChatParticipants
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1061556205)]
  public class TLChatParticipants : TLAbsChatParticipants
  {
    public override int Constructor => 1061556205;

    public int ChatId { get; set; }

    public TLVector<TLAbsChatParticipant> Participants { get; set; }

    public int Version { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ChatId = br.ReadInt32();
      this.Participants = ObjectUtils.DeserializeVector<TLAbsChatParticipant>(br);
      this.Version = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChatId);
      ObjectUtils.SerializeObject((object) this.Participants, bw);
      bw.Write(this.Version);
    }
  }
}
