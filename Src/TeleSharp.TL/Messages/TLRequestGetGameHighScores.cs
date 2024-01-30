// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestGetGameHighScores
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-400399203)]
  public class TLRequestGetGameHighScores : TLMethod
  {
    public override int Constructor => -400399203;

    public TLAbsInputPeer Peer { get; set; }

    public int Id { get; set; }

    public TLAbsInputUser UserId { get; set; }

    public TLHighScores Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.Id = br.ReadInt32();
      this.UserId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.Id);
      ObjectUtils.SerializeObject((object) this.UserId, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLHighScores) ObjectUtils.DeserializeObject(br);
    }
  }
}
