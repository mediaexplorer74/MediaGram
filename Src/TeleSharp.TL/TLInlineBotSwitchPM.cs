// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInlineBotSwitchPM
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1008755359)]
  public class TLInlineBotSwitchPM : TLObject
  {
    public override int Constructor => 1008755359;

    public string Text { get; set; }

    public string StartParam { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Text = StringUtil.Deserialize(br);
      this.StartParam = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Text, bw);
      StringUtil.Serialize(this.StartParam, bw);
    }
  }
}
