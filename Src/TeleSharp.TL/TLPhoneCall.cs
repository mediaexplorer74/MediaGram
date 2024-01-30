﻿// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLPhoneCall
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1660057)]
  public class TLPhoneCall : TLAbsPhoneCall
  {
    public override int Constructor => -1660057;

    public long Id { get; set; }

    public long AccessHash { get; set; }

    public int Date { get; set; }

    public int AdminId { get; set; }

    public int ParticipantId { get; set; }

    public byte[] GAOrB { get; set; }

    public long KeyFingerprint { get; set; }

    public TLPhoneCallProtocol Protocol { get; set; }

    public TLPhoneConnection Connection { get; set; }

    public TLVector<TLPhoneConnection> AlternativeConnections { get; set; }

    public int StartDate { get; set; }

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
      this.GAOrB = BytesUtil.Deserialize(br);
      this.KeyFingerprint = br.ReadInt64();
      this.Protocol = (TLPhoneCallProtocol) ObjectUtils.DeserializeObject(br);
      this.Connection = (TLPhoneConnection) ObjectUtils.DeserializeObject(br);
      this.AlternativeConnections = ObjectUtils.DeserializeVector<TLPhoneConnection>(br);
      this.StartDate = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      bw.Write(this.AccessHash);
      bw.Write(this.Date);
      bw.Write(this.AdminId);
      bw.Write(this.ParticipantId);
      BytesUtil.Serialize(this.GAOrB, bw);
      bw.Write(this.KeyFingerprint);
      ObjectUtils.SerializeObject((object) this.Protocol, bw);
      ObjectUtils.SerializeObject((object) this.Connection, bw);
      ObjectUtils.SerializeObject((object) this.AlternativeConnections, bw);
      bw.Write(this.StartDate);
    }
  }
}
