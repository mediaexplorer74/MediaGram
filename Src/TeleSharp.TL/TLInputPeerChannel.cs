// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputPeerChannel
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(548253432)]
  public class TLInputPeerChannel : TLAbsInputPeer
  {
    public override int Constructor => 548253432;

    public int ChannelId { get; set; }

    public long AccessHash { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ChannelId = br.ReadInt32();
      this.AccessHash = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChannelId);
      bw.Write(this.AccessHash);
    }
  }
}
