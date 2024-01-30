// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestSearch
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-732523960)]
  public class TLRequestSearch : TLMethod
  {
    public override int Constructor => -732523960;

    public int Flags { get; set; }

    public TLAbsInputPeer Peer { get; set; }

    public string Q { get; set; }

    public TLAbsMessagesFilter Filter { get; set; }

    public int MinDate { get; set; }

    public int MaxDate { get; set; }

    public int Offset { get; set; }

    public int MaxId { get; set; }

    public int Limit { get; set; }

    public TLAbsMessages Response { get; set; }

    public void ComputeFlags() => this.Flags = 0;

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.Q = StringUtil.Deserialize(br);
      this.Filter = (TLAbsMessagesFilter) ObjectUtils.DeserializeObject(br);
      this.MinDate = br.ReadInt32();
      this.MaxDate = br.ReadInt32();
      this.Offset = br.ReadInt32();
      this.MaxId = br.ReadInt32();
      this.Limit = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      StringUtil.Serialize(this.Q, bw);
      ObjectUtils.SerializeObject((object) this.Filter, bw);
      bw.Write(this.MinDate);
      bw.Write(this.MaxDate);
      bw.Write(this.Offset);
      bw.Write(this.MaxId);
      bw.Write(this.Limit);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsMessages) ObjectUtils.DeserializeObject(br);
    }
  }
}
