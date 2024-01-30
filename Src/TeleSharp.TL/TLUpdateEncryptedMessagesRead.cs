// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateEncryptedMessagesRead
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(956179895)]
  public class TLUpdateEncryptedMessagesRead : TLAbsUpdate
  {
    public override int Constructor => 956179895;

    public int ChatId { get; set; }

    public int MaxDate { get; set; }

    public int Date { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ChatId = br.ReadInt32();
      this.MaxDate = br.ReadInt32();
      this.Date = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChatId);
      bw.Write(this.MaxDate);
      bw.Write(this.Date);
    }
  }
}
