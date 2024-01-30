﻿// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLBotResults
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-858565059)]
  public class TLBotResults : TLObject
  {
    public override int Constructor => -858565059;

    public int Flags { get; set; }

    public bool Gallery { get; set; }

    public long QueryId { get; set; }

    public string NextOffset { get; set; }

    public TLInlineBotSwitchPM SwitchPm { get; set; }

    public TLVector<TLAbsBotInlineResult> Results { get; set; }

    public int CacheTime { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Gallery ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.NextOffset != null ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.SwitchPm != null ? this.Flags | 4 : this.Flags & -5;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Gallery = (this.Flags & 1) != 0;
      this.QueryId = br.ReadInt64();
      this.NextOffset = (this.Flags & 2) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.SwitchPm = (this.Flags & 4) == 0 ? (TLInlineBotSwitchPM) null : (TLInlineBotSwitchPM) ObjectUtils.DeserializeObject(br);
      this.Results = ObjectUtils.DeserializeVector<TLAbsBotInlineResult>(br);
      this.CacheTime = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.QueryId);
      if ((this.Flags & 2) != 0)
        StringUtil.Serialize(this.NextOffset, bw);
      if ((this.Flags & 4) != 0)
        ObjectUtils.SerializeObject((object) this.SwitchPm, bw);
      ObjectUtils.SerializeObject((object) this.Results, bw);
      bw.Write(this.CacheTime);
    }
  }
}
