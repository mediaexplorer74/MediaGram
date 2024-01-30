// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputEncryptedFileBigUploaded
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(767652808)]
  public class TLInputEncryptedFileBigUploaded : TLAbsInputEncryptedFile
  {
    public override int Constructor => 767652808;

    public long Id { get; set; }

    public int Parts { get; set; }

    public int KeyFingerprint { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt64();
      this.Parts = br.ReadInt32();
      this.KeyFingerprint = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      bw.Write(this.Parts);
      bw.Write(this.KeyFingerprint);
    }
  }
}
