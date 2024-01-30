// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLPeerDialogs
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;
using TeleSharp.TL.Updates;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(863093588)]
  public class TLPeerDialogs : TLObject
  {
    public override int Constructor => 863093588;

    public TLVector<TLDialog> Dialogs { get; set; }

    public TLVector<TLAbsMessage> Messages { get; set; }

    public TLVector<TLAbsChat> Chats { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public TLState State { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Dialogs = ObjectUtils.DeserializeVector<TLDialog>(br);
      this.Messages = ObjectUtils.DeserializeVector<TLAbsMessage>(br);
      this.Chats = ObjectUtils.DeserializeVector<TLAbsChat>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
      this.State = (TLState) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Dialogs, bw);
      ObjectUtils.SerializeObject((object) this.Messages, bw);
      ObjectUtils.SerializeObject((object) this.Chats, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
      ObjectUtils.SerializeObject((object) this.State, bw);
    }
  }
}
