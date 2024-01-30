// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Channels.TLRequestGetChannels
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;
using TeleSharp.TL.Messages;

#nullable disable
namespace TeleSharp.TL.Channels
{
  [TLObject(176122811)]
  public class TLRequestGetChannels : TLMethod
  {
    public override int Constructor => 176122811;

    public TLVector<TLAbsInputChannel> Id { get; set; }

    public TLAbsChats Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = ObjectUtils.DeserializeVector<TLAbsInputChannel>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsChats) ObjectUtils.DeserializeObject(br);
    }
  }
}
