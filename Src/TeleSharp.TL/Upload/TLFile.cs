// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Upload.TLFile
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;
using TeleSharp.TL.Storage;

#nullable disable
namespace TeleSharp.TL.Upload
{
  [TLObject(157948117)]
  public class TLFile : TLAbsFile
  {
    public override int Constructor => 157948117;

    public TLAbsFileType Type { get; set; }

    public int Mtime { get; set; }

    public byte[] Bytes { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Type = (TLAbsFileType) ObjectUtils.DeserializeObject(br);
      this.Mtime = br.ReadInt32();
      this.Bytes = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Type, bw);
      bw.Write(this.Mtime);
      BytesUtil.Serialize(this.Bytes, bw);
    }
  }
}
