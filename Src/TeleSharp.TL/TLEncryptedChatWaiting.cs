// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLEncryptedChatWaiting
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1006044124)]
  public class TLEncryptedChatWaiting : TLAbsEncryptedChat
  {
    public override int Constructor => 1006044124;

    public int Id { get; set; }

    public long AccessHash { get; set; }

    public int Date { get; set; }

    public int AdminId { get; set; }

    public int ParticipantId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt32();
      this.AccessHash = br.ReadInt64();
      this.Date = br.ReadInt32();
      this.AdminId = br.ReadInt32();
      this.ParticipantId = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      bw.Write(this.AccessHash);
      bw.Write(this.Date);
      bw.Write(this.AdminId);
      bw.Write(this.ParticipantId);
    }
  }
}
