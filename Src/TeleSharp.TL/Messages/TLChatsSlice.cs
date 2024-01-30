// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLChatsSlice
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-1663561404)]
  public class TLChatsSlice : TLAbsChats
  {
    public override int Constructor => -1663561404;

    public int Count { get; set; }

    public TLVector<TLAbsChat> Chats { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Count = br.ReadInt32();
      this.Chats = ObjectUtils.DeserializeVector<TLAbsChat>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Count);
      ObjectUtils.SerializeObject((object) this.Chats, bw);
    }
  }
}
