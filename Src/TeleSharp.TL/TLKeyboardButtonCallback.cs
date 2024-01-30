// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLKeyboardButtonCallback
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1748655686)]
  public class TLKeyboardButtonCallback : TLAbsKeyboardButton
  {
    public override int Constructor => 1748655686;

    public string Text { get; set; }

    public byte[] Data { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Text = StringUtil.Deserialize(br);
      this.Data = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Text, bw);
      BytesUtil.Serialize(this.Data, bw);
    }
  }
}
