// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestGetInlineGameHighScores
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(258170395)]
  public class TLRequestGetInlineGameHighScores : TLMethod
  {
    public override int Constructor => 258170395;

    public TLInputBotInlineMessageID Id { get; set; }

    public TLAbsInputUser UserId { get; set; }

    public TLHighScores Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = (TLInputBotInlineMessageID) ObjectUtils.DeserializeObject(br);
      this.UserId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
      ObjectUtils.SerializeObject((object) this.UserId, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLHighScores) ObjectUtils.DeserializeObject(br);
    }
  }
}
