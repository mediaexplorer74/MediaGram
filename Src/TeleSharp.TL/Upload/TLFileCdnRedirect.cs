// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Upload.TLFileCdnRedirect
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Upload
{
  [TLObject(352864346)]
  public class TLFileCdnRedirect : TLAbsFile
  {
    public override int Constructor => 352864346;

    public int DcId { get; set; }

    public byte[] FileToken { get; set; }

    public byte[] EncryptionKey { get; set; }

    public byte[] EncryptionIv { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.DcId = br.ReadInt32();
      this.FileToken = BytesUtil.Deserialize(br);
      this.EncryptionKey = BytesUtil.Deserialize(br);
      this.EncryptionIv = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.DcId);
      BytesUtil.Serialize(this.FileToken, bw);
      BytesUtil.Serialize(this.EncryptionKey, bw);
      BytesUtil.Serialize(this.EncryptionIv, bw);
    }
  }
}
