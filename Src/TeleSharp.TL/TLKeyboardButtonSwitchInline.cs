// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLKeyboardButtonSwitchInline
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(90744648)]
  public class TLKeyboardButtonSwitchInline : TLAbsKeyboardButton
  {
    public override int Constructor => 90744648;

    public int Flags { get; set; }

    public bool SamePeer { get; set; }

    public string Text { get; set; }

    public string Query { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.SamePeer ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.SamePeer = (this.Flags & 1) != 0;
      this.Text = StringUtil.Deserialize(br);
      this.Query = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      StringUtil.Serialize(this.Text, bw);
      StringUtil.Serialize(this.Query, bw);
    }
  }
}
