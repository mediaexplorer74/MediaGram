// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLPhotoSize
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(2009052699)]
  public class TLPhotoSize : TLAbsPhotoSize
  {
    public override int Constructor => 2009052699;

    public string Type { get; set; }

    public TLAbsFileLocation Location { get; set; }

    public int W { get; set; }

    public int H { get; set; }

    public int Size { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Type = StringUtil.Deserialize(br);
      this.Location = (TLAbsFileLocation) ObjectUtils.DeserializeObject(br);
      this.W = br.ReadInt32();
      this.H = br.ReadInt32();
      this.Size = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Type, bw);
      ObjectUtils.SerializeObject((object) this.Location, bw);
      bw.Write(this.W);
      bw.Write(this.H);
      bw.Write(this.Size);
    }
  }
}
