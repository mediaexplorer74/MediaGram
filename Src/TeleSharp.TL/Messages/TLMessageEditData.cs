// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLMessageEditData
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(649453030)]
  public class TLMessageEditData : TLObject
  {
    public override int Constructor => 649453030;

    public int Flags { get; set; }

    public bool Caption { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Caption ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Caption = (this.Flags & 1) != 0;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
    }
  }
}
