// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputBotInlineResultPhoto
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1462213465)]
  public class TLInputBotInlineResultPhoto : TLAbsInputBotInlineResult
  {
    public override int Constructor => -1462213465;

    public string Id { get; set; }

    public string Type { get; set; }

    public TLAbsInputPhoto Photo { get; set; }

    public TLAbsInputBotInlineMessage SendMessage { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = StringUtil.Deserialize(br);
      this.Type = StringUtil.Deserialize(br);
      this.Photo = (TLAbsInputPhoto) ObjectUtils.DeserializeObject(br);
      this.SendMessage = (TLAbsInputBotInlineMessage) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Id, bw);
      StringUtil.Serialize(this.Type, bw);
      ObjectUtils.SerializeObject((object) this.Photo, bw);
      ObjectUtils.SerializeObject((object) this.SendMessage, bw);
    }
  }
}
