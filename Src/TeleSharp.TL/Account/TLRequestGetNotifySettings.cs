﻿// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Account.TLRequestGetNotifySettings
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Account
{
  [TLObject(313765169)]
  public class TLRequestGetNotifySettings : TLMethod
  {
    public override int Constructor => 313765169;

    public TLAbsInputNotifyPeer Peer { get; set; }

    public TLAbsPeerNotifySettings Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLAbsInputNotifyPeer) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsPeerNotifySettings) ObjectUtils.DeserializeObject(br);
    }
  }
}
