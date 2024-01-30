// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Channels.TLRequestGetParticipants
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Channels
{
  [TLObject(618237842)]
  public class TLRequestGetParticipants : TLMethod
  {
    public override int Constructor => 618237842;

    public TLAbsInputChannel Channel { get; set; }

    public TLAbsChannelParticipantsFilter Filter { get; set; }

    public int Offset { get; set; }

    public int Limit { get; set; }

    public TLChannelParticipants Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Channel = (TLAbsInputChannel) ObjectUtils.DeserializeObject(br);
      this.Filter = (TLAbsChannelParticipantsFilter) ObjectUtils.DeserializeObject(br);
      this.Offset = br.ReadInt32();
      this.Limit = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Channel, bw);
      ObjectUtils.SerializeObject((object) this.Filter, bw);
      bw.Write(this.Offset);
      bw.Write(this.Limit);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLChannelParticipants) ObjectUtils.DeserializeObject(br);
    }
  }
}
