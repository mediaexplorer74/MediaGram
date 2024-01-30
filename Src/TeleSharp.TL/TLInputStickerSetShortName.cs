// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputStickerSetShortName
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-2044933984)]
  public class TLInputStickerSetShortName : TLAbsInputStickerSet
  {
    public override int Constructor => -2044933984;

    public string ShortName { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ShortName = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.ShortName, bw);
    }
  }
}
