// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLPhoneCallRequested
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-2089411356)]
  public class TLPhoneCallRequested : TLAbsPhoneCall
  {
    public override int Constructor => -2089411356;

    public long Id { get; set; }

    public long AccessHash { get; set; }

    public int Date { get; set; }

    public int AdminId { get; set; }

    public int ParticipantId { get; set; }

    public byte[] GAHash { get; set; }

    public TLPhoneCallProtocol Protocol { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt64();
      this.AccessHash = br.ReadInt64();
      this.Date = br.ReadInt32();
      this.AdminId = br.ReadInt32();
      this.ParticipantId = br.ReadInt32();
      this.GAHash = BytesUtil.Deserialize(br);
      this.Protocol = (TLPhoneCallProtocol) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      bw.Write(this.AccessHash);
      bw.Write(this.Date);
      bw.Write(this.AdminId);
      bw.Write(this.ParticipantId);
      BytesUtil.Serialize(this.GAHash, bw);
      ObjectUtils.SerializeObject((object) this.Protocol, bw);
    }
  }
}
