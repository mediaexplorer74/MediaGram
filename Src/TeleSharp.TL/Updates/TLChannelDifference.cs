﻿// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Updates.TLChannelDifference
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Updates
{
  [TLObject(543450958)]
  public class TLChannelDifference : TLAbsChannelDifference
  {
    public override int Constructor => 543450958;

    public int Flags { get; set; }

    public bool Final { get; set; }

    public int Pts { get; set; }

    public int? Timeout { get; set; }

    public TLVector<TLAbsMessage> NewMessages { get; set; }

    public TLVector<TLAbsUpdate> OtherUpdates { get; set; }

    public TLVector<TLAbsChat> Chats { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Final ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Timeout.HasValue ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Final = (this.Flags & 1) != 0;
      this.Pts = br.ReadInt32();
      this.Timeout = (this.Flags & 2) == 0 ? new int?() : new int?(br.ReadInt32());
      this.NewMessages = ObjectUtils.DeserializeVector<TLAbsMessage>(br);
      this.OtherUpdates = ObjectUtils.DeserializeVector<TLAbsUpdate>(br);
      this.Chats = ObjectUtils.DeserializeVector<TLAbsChat>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Pts);
      if ((this.Flags & 2) != 0)
        bw.Write(this.Timeout.Value);
      ObjectUtils.SerializeObject((object) this.NewMessages, bw);
      ObjectUtils.SerializeObject((object) this.OtherUpdates, bw);
      ObjectUtils.SerializeObject((object) this.Chats, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
