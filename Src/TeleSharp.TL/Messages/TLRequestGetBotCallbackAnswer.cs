// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestGetBotCallbackAnswer
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-2130010132)]
  public class TLRequestGetBotCallbackAnswer : TLMethod
  {
    public override int Constructor => -2130010132;

    public int Flags { get; set; }

    public bool Game { get; set; }

    public TLAbsInputPeer Peer { get; set; }

    public int MsgId { get; set; }

    public byte[] Data { get; set; }

    public TLBotCallbackAnswer Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Game ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Data != null ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Game = (this.Flags & 2) != 0;
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.MsgId = br.ReadInt32();
      if ((this.Flags & 1) != 0)
        this.Data = BytesUtil.Deserialize(br);
      else
        this.Data = (byte[]) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.MsgId);
      if ((this.Flags & 1) == 0)
        return;
      BytesUtil.Serialize(this.Data, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLBotCallbackAnswer) ObjectUtils.DeserializeObject(br);
    }
  }
}
