// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLSavedGifs
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(772213157)]
  public class TLSavedGifs : TLAbsSavedGifs
  {
    public override int Constructor => 772213157;

    public int Hash { get; set; }

    public TLVector<TLAbsDocument> Gifs { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Hash = br.ReadInt32();
      this.Gifs = ObjectUtils.DeserializeVector<TLAbsDocument>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Hash);
      ObjectUtils.SerializeObject((object) this.Gifs, bw);
    }
  }
}
