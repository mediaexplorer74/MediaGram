// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputBotInlineResultGame
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1336154098)]
  public class TLInputBotInlineResultGame : TLAbsInputBotInlineResult
  {
    public override int Constructor => 1336154098;

    public string Id { get; set; }

    public string ShortName { get; set; }

    public TLAbsInputBotInlineMessage SendMessage { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = StringUtil.Deserialize(br);
      this.ShortName = StringUtil.Deserialize(br);
      this.SendMessage = (TLAbsInputBotInlineMessage) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Id, bw);
      StringUtil.Serialize(this.ShortName, bw);
      ObjectUtils.SerializeObject((object) this.SendMessage, bw);
    }
  }
}
