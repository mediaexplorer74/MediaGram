﻿// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateReadChannelInbox
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1108669311)]
  public class TLUpdateReadChannelInbox : TLAbsUpdate
  {
    public override int Constructor => 1108669311;

    public int ChannelId { get; set; }

    public int MaxId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ChannelId = br.ReadInt32();
      this.MaxId = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChannelId);
      bw.Write(this.MaxId);
    }
  }
}
