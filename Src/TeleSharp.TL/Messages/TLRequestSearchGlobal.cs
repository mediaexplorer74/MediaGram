﻿// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestSearchGlobal
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-1640190800)]
  public class TLRequestSearchGlobal : TLMethod
  {
    public override int Constructor => -1640190800;

    public string Q { get; set; }

    public int OffsetDate { get; set; }

    public TLAbsInputPeer OffsetPeer { get; set; }

    public int OffsetId { get; set; }

    public int Limit { get; set; }

    public TLAbsMessages Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Q = StringUtil.Deserialize(br);
      this.OffsetDate = br.ReadInt32();
      this.OffsetPeer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.OffsetId = br.ReadInt32();
      this.Limit = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Q, bw);
      bw.Write(this.OffsetDate);
      ObjectUtils.SerializeObject((object) this.OffsetPeer, bw);
      bw.Write(this.OffsetId);
      bw.Write(this.Limit);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsMessages) ObjectUtils.DeserializeObject(br);
    }
  }
}
