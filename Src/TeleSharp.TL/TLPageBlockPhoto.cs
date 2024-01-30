﻿// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLPageBlockPhoto
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-372860542)]
  public class TLPageBlockPhoto : TLAbsPageBlock
  {
    public override int Constructor => -372860542;

    public long PhotoId { get; set; }

    public TLAbsRichText Caption { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PhotoId = br.ReadInt64();
      this.Caption = (TLAbsRichText) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.PhotoId);
      ObjectUtils.SerializeObject((object) this.Caption, bw);
    }
  }
}
