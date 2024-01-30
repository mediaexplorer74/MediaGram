// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestEditChatPhoto
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-900957736)]
  public class TLRequestEditChatPhoto : TLMethod
  {
    public override int Constructor => -900957736;

    public int ChatId { get; set; }

    public TLAbsInputChatPhoto Photo { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ChatId = br.ReadInt32();
      this.Photo = (TLAbsInputChatPhoto) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChatId);
      ObjectUtils.SerializeObject((object) this.Photo, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
    }
  }
}
