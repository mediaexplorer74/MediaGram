// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLTextConcat
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(2120376535)]
  public class TLTextConcat : TLAbsRichText
  {
    public override int Constructor => 2120376535;

    public TLVector<TLAbsRichText> Texts { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Texts = ObjectUtils.DeserializeVector<TLAbsRichText>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Texts, bw);
    }
  }
}
