// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Updates.TLDifference
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Updates
{
  [TLObject(16030880)]
  public class TLDifference : TLAbsDifference
  {
    public override int Constructor => 16030880;

    public TLVector<TLAbsMessage> NewMessages { get; set; }

    public TLVector<TLAbsEncryptedMessage> NewEncryptedMessages { get; set; }

    public TLVector<TLAbsUpdate> OtherUpdates { get; set; }

    public TLVector<TLAbsChat> Chats { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public TLState State { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.NewMessages = ObjectUtils.DeserializeVector<TLAbsMessage>(br);
      this.NewEncryptedMessages = ObjectUtils.DeserializeVector<TLAbsEncryptedMessage>(br);
      this.OtherUpdates = ObjectUtils.DeserializeVector<TLAbsUpdate>(br);
      this.Chats = ObjectUtils.DeserializeVector<TLAbsChat>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
      this.State = (TLState) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.NewMessages, bw);
      ObjectUtils.SerializeObject((object) this.NewEncryptedMessages, bw);
      ObjectUtils.SerializeObject((object) this.OtherUpdates, bw);
      ObjectUtils.SerializeObject((object) this.Chats, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
      ObjectUtils.SerializeObject((object) this.State, bw);
    }
  }
}
