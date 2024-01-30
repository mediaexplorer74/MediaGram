// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Phone.TLRequestSetCallRating
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Phone
{
  [TLObject(475228724)]
  public class TLRequestSetCallRating : TLMethod
  {
    public override int Constructor => 475228724;

    public TLInputPhoneCall Peer { get; set; }

    public int Rating { get; set; }

    public string Comment { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLInputPhoneCall) ObjectUtils.DeserializeObject(br);
      this.Rating = br.ReadInt32();
      this.Comment = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.Rating);
      StringUtil.Serialize(this.Comment, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
    }
  }
}
