// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLEncryptedMessageService
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(594758406)]
  public class TLEncryptedMessageService : TLAbsEncryptedMessage
  {
    public override int Constructor => 594758406;

    public long RandomId { get; set; }

    public int ChatId { get; set; }

    public int Date { get; set; }

    public byte[] Bytes { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.RandomId = br.ReadInt64();
      this.ChatId = br.ReadInt32();
      this.Date = br.ReadInt32();
      this.Bytes = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.RandomId);
      bw.Write(this.ChatId);
      bw.Write(this.Date);
      BytesUtil.Serialize(this.Bytes, bw);
    }
  }
}
