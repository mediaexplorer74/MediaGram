// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLArchivedStickers
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(1338747336)]
  public class TLArchivedStickers : TLObject
  {
    public override int Constructor => 1338747336;

    public int Count { get; set; }

    public TLVector<TLAbsStickerSetCovered> Sets { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Count = br.ReadInt32();
      this.Sets = ObjectUtils.DeserializeVector<TLAbsStickerSetCovered>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Count);
      ObjectUtils.SerializeObject((object) this.Sets, bw);
    }
  }
}
