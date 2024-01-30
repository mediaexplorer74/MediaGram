// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLReplyKeyboardForceReply
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-200242528)]
  public class TLReplyKeyboardForceReply : TLAbsReplyMarkup
  {
    public override int Constructor => -200242528;

    public int Flags { get; set; }

    public bool SingleUse { get; set; }

    public bool Selective { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.SingleUse ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Selective ? this.Flags | 4 : this.Flags & -5;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.SingleUse = (this.Flags & 2) != 0;
      this.Selective = (this.Flags & 4) != 0;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
    }
  }
}
