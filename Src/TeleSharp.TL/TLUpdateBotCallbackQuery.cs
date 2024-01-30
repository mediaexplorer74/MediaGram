// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateBotCallbackQuery
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-415938591)]
  public class TLUpdateBotCallbackQuery : TLAbsUpdate
  {
    public override int Constructor => -415938591;

    public int Flags { get; set; }

    public long QueryId { get; set; }

    public int UserId { get; set; }

    public TLAbsPeer Peer { get; set; }

    public int MsgId { get; set; }

    public long ChatInstance { get; set; }

    public byte[] Data { get; set; }

    public string GameShortName { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Data != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.GameShortName != null ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.QueryId = br.ReadInt64();
      this.UserId = br.ReadInt32();
      this.Peer = (TLAbsPeer) ObjectUtils.DeserializeObject(br);
      this.MsgId = br.ReadInt32();
      this.ChatInstance = br.ReadInt64();
      this.Data = (this.Flags & 1) == 0 ? (byte[]) null : BytesUtil.Deserialize(br);
      if ((this.Flags & 2) != 0)
        this.GameShortName = StringUtil.Deserialize(br);
      else
        this.GameShortName = (string) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.QueryId);
      bw.Write(this.UserId);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.MsgId);
      bw.Write(this.ChatInstance);
      if ((this.Flags & 1) != 0)
        BytesUtil.Serialize(this.Data, bw);
      if ((this.Flags & 2) == 0)
        return;
      StringUtil.Serialize(this.GameShortName, bw);
    }
  }
}
