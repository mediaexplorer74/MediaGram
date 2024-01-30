// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestEditChatAdmin
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-1444503762)]
  public class TLRequestEditChatAdmin : TLMethod
  {
    public override int Constructor => -1444503762;

    public int ChatId { get; set; }

    public TLAbsInputUser UserId { get; set; }

    public bool IsAdmin { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ChatId = br.ReadInt32();
      this.UserId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
      this.IsAdmin = BoolUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChatId);
      ObjectUtils.SerializeObject((object) this.UserId, bw);
      BoolUtil.Serialize(this.IsAdmin, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = BoolUtil.Deserialize(br);
    }
  }
}
