﻿// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLDhConfigNotModified
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-1058912715)]
  public class TLDhConfigNotModified : TLAbsDhConfig
  {
    public override int Constructor => -1058912715;

    public byte[] Random { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Random = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BytesUtil.Serialize(this.Random, bw);
    }
  }
}
