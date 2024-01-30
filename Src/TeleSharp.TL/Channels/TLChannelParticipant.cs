// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Channels.TLChannelParticipant
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Channels
{
  [TLObject(-791039645)]
  public class TLChannelParticipant : TLObject
  {
    public override int Constructor => -791039645;

    public TLAbsChannelParticipant Participant { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Participant = (TLAbsChannelParticipant) ObjectUtils.DeserializeObject(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Participant, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
