// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLKeyboardButtonRow
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(2002815875)]
  public class TLKeyboardButtonRow : TLObject
  {
    public override int Constructor => 2002815875;

    public TLVector<TLAbsKeyboardButton> Buttons { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Buttons = ObjectUtils.DeserializeVector<TLAbsKeyboardButton>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Buttons, bw);
    }
  }
}
