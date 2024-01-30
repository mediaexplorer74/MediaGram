// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLSentEncryptedMessage
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(1443858741)]
  public class TLSentEncryptedMessage : TLAbsSentEncryptedMessage
  {
    public override int Constructor => 1443858741;

    public int Date { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Date = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Date);
    }
  }
}
