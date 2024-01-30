// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputGameShortName
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1020139510)]
  public class TLInputGameShortName : TLAbsInputGame
  {
    public override int Constructor => -1020139510;

    public TLAbsInputUser BotId { get; set; }

    public string ShortName { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.BotId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
      this.ShortName = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.BotId, bw);
      StringUtil.Serialize(this.ShortName, bw);
    }
  }
}
