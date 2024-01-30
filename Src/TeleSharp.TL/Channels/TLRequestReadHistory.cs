﻿// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Channels.TLRequestReadHistory
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Channels
{
  [TLObject(-871347913)]
  public class TLRequestReadHistory : TLMethod
  {
    public override int Constructor => -871347913;

    public TLAbsInputChannel Channel { get; set; }

    public int MaxId { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Channel = (TLAbsInputChannel) ObjectUtils.DeserializeObject(br);
      this.MaxId = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Channel, bw);
      bw.Write(this.MaxId);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = BoolUtil.Deserialize(br);
    }
  }
}
