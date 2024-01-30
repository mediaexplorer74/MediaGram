// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Upload.TLRequestSaveBigFilePart
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Upload
{
  [TLObject(-562337987)]
  public class TLRequestSaveBigFilePart : TLMethod
  {
    public override int Constructor => -562337987;

    public long FileId { get; set; }

    public int FilePart { get; set; }

    public int FileTotalParts { get; set; }

    public byte[] Bytes { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.FileId = br.ReadInt64();
      this.FilePart = br.ReadInt32();
      this.FileTotalParts = br.ReadInt32();
      this.Bytes = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.FileId);
      bw.Write(this.FilePart);
      bw.Write(this.FileTotalParts);
      BytesUtil.Serialize(this.Bytes, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = BoolUtil.Deserialize(br);
    }
  }
}
