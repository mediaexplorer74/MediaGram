// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Channels.TLChannelParticipants
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Channels
{
  [TLObject(-177282392)]
  public class TLChannelParticipants : TLObject
  {
    public override int Constructor => -177282392;

    public int Count { get; set; }

    public TLVector<TLAbsChannelParticipant> Participants { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Count = br.ReadInt32();
      this.Participants = ObjectUtils.DeserializeVector<TLAbsChannelParticipant>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Count);
      ObjectUtils.SerializeObject((object) this.Participants, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
