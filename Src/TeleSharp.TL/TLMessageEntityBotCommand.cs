// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLMessageEntityBotCommand
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1827637959)]
  public class TLMessageEntityBotCommand : TLAbsMessageEntity
  {
    public override int Constructor => 1827637959;

    public int Offset { get; set; }

    public int Length { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Offset = br.ReadInt32();
      this.Length = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Offset);
      bw.Write(this.Length);
    }
  }
}
