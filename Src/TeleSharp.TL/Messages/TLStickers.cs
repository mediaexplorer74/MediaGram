// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLStickers
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-1970352846)]
  public class TLStickers : TLAbsStickers
  {
    public override int Constructor => -1970352846;

    public string Hash { get; set; }

    public TLVector<TLAbsDocument> Stickers { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Hash = StringUtil.Deserialize(br);
      this.Stickers = ObjectUtils.DeserializeVector<TLAbsDocument>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Hash, bw);
      ObjectUtils.SerializeObject((object) this.Stickers, bw);
    }
  }
}
