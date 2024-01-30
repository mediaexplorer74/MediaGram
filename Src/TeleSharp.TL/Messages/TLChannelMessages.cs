// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLChannelMessages
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-1725551049)]
  public class TLChannelMessages : TLAbsMessages
  {
    public override int Constructor => -1725551049;

    public int Flags { get; set; }

    public int Pts { get; set; }

    public int Count { get; set; }

    public TLVector<TLAbsMessage> Messages { get; set; }

    public TLVector<TLAbsChat> Chats { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags() => this.Flags = 0;

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Pts = br.ReadInt32();
      this.Count = br.ReadInt32();
      this.Messages = ObjectUtils.DeserializeVector<TLAbsMessage>(br);
      this.Chats = ObjectUtils.DeserializeVector<TLAbsChat>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Pts);
      bw.Write(this.Count);
      ObjectUtils.SerializeObject((object) this.Messages, bw);
      ObjectUtils.SerializeObject((object) this.Chats, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
