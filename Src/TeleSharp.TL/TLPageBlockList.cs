// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLPageBlockList
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(978896884)]
  public class TLPageBlockList : TLAbsPageBlock
  {
    public override int Constructor => 978896884;

    public bool Ordered { get; set; }

    public TLVector<TLAbsRichText> Items { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Ordered = BoolUtil.Deserialize(br);
      this.Items = ObjectUtils.DeserializeVector<TLAbsRichText>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BoolUtil.Serialize(this.Ordered, bw);
      ObjectUtils.SerializeObject((object) this.Items, bw);
    }
  }
}
