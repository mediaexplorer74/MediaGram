// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLKeyboardButtonUrl
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(629866245)]
  public class TLKeyboardButtonUrl : TLAbsKeyboardButton
  {
    public override int Constructor => 629866245;

    public string Text { get; set; }

    public string Url { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Text = StringUtil.Deserialize(br);
      this.Url = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Text, bw);
      StringUtil.Serialize(this.Url, bw);
    }
  }
}
