// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLSentEncryptedFile
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-1802240206)]
  public class TLSentEncryptedFile : TLAbsSentEncryptedMessage
  {
    public override int Constructor => -1802240206;

    public int Date { get; set; }

    public TLAbsEncryptedFile File { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Date = br.ReadInt32();
      this.File = (TLAbsEncryptedFile) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Date);
      ObjectUtils.SerializeObject((object) this.File, bw);
    }
  }
}
