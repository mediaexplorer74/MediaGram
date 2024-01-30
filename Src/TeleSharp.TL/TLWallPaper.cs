// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLWallPaper
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-860866985)]
  public class TLWallPaper : TLAbsWallPaper
  {
    public override int Constructor => -860866985;

    public int Id { get; set; }

    public string Title { get; set; }

    public TLVector<TLAbsPhotoSize> Sizes { get; set; }

    public int Color { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt32();
      this.Title = StringUtil.Deserialize(br);
      this.Sizes = ObjectUtils.DeserializeVector<TLAbsPhotoSize>(br);
      this.Color = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      StringUtil.Serialize(this.Title, bw);
      ObjectUtils.SerializeObject((object) this.Sizes, bw);
      bw.Write(this.Color);
    }
  }
}
