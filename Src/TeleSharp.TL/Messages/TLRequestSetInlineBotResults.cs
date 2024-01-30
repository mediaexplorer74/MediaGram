// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestSetInlineBotResults
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-346119674)]
  public class TLRequestSetInlineBotResults : TLMethod
  {
    public override int Constructor => -346119674;

    public int Flags { get; set; }

    public bool Gallery { get; set; }

    public bool Private { get; set; }

    public long QueryId { get; set; }

    public TLVector<TLAbsInputBotInlineResult> Results { get; set; }

    public int CacheTime { get; set; }

    public string NextOffset { get; set; }

    public TLInlineBotSwitchPM SwitchPm { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Gallery ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Private ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.NextOffset != null ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.SwitchPm != null ? this.Flags | 8 : this.Flags & -9;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Gallery = (this.Flags & 1) != 0;
      this.Private = (this.Flags & 2) != 0;
      this.QueryId = br.ReadInt64();
      this.Results = ObjectUtils.DeserializeVector<TLAbsInputBotInlineResult>(br);
      this.CacheTime = br.ReadInt32();
      this.NextOffset = (this.Flags & 4) == 0 ? (string) null : StringUtil.Deserialize(br);
      if ((this.Flags & 8) != 0)
        this.SwitchPm = (TLInlineBotSwitchPM) ObjectUtils.DeserializeObject(br);
      else
        this.SwitchPm = (TLInlineBotSwitchPM) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.QueryId);
      ObjectUtils.SerializeObject((object) this.Results, bw);
      bw.Write(this.CacheTime);
      if ((this.Flags & 4) != 0)
        StringUtil.Serialize(this.NextOffset, bw);
      if ((this.Flags & 8) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.SwitchPm, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = BoolUtil.Deserialize(br);
    }
  }
}
