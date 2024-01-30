// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLStickerPack
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(313694676)]
  public class TLStickerPack : TLObject
  {
    public override int Constructor => 313694676;

    public string Emoticon { get; set; }

    public TLVector<long> Documents { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Emoticon = StringUtil.Deserialize(br);
      this.Documents = ObjectUtils.DeserializeVector<long>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Emoticon, bw);
      ObjectUtils.SerializeObject((object) this.Documents, bw);
    }
  }
}
