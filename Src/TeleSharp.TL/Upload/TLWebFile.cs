// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Upload.TLWebFile
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;
using TeleSharp.TL.Storage;

#nullable disable
namespace TeleSharp.TL.Upload
{
  [TLObject(568808380)]
  public class TLWebFile : TLObject
  {
    public override int Constructor => 568808380;

    public int Size { get; set; }

    public string MimeType { get; set; }

    public TLAbsFileType FileType { get; set; }

    public int Mtime { get; set; }

    public byte[] Bytes { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Size = br.ReadInt32();
      this.MimeType = StringUtil.Deserialize(br);
      this.FileType = (TLAbsFileType) ObjectUtils.DeserializeObject(br);
      this.Mtime = br.ReadInt32();
      this.Bytes = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Size);
      StringUtil.Serialize(this.MimeType, bw);
      ObjectUtils.SerializeObject((object) this.FileType, bw);
      bw.Write(this.Mtime);
      BytesUtil.Serialize(this.Bytes, bw);
    }
  }
}
