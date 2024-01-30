// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLChannelParticipantEditor
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1743180447)]
  public class TLChannelParticipantEditor : TLAbsChannelParticipant
  {
    public override int Constructor => -1743180447;

    public int UserId { get; set; }

    public int InviterId { get; set; }

    public int Date { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = br.ReadInt32();
      this.InviterId = br.ReadInt32();
      this.Date = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.UserId);
      bw.Write(this.InviterId);
      bw.Write(this.Date);
    }
  }
}
