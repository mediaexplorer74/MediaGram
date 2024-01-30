﻿// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLFoundGif
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(372165663)]
  public class TLFoundGif : TLAbsFoundGif
  {
    public override int Constructor => 372165663;

    public string Url { get; set; }

    public string ThumbUrl { get; set; }

    public string ContentUrl { get; set; }

    public string ContentType { get; set; }

    public int W { get; set; }

    public int H { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Url = StringUtil.Deserialize(br);
      this.ThumbUrl = StringUtil.Deserialize(br);
      this.ContentUrl = StringUtil.Deserialize(br);
      this.ContentType = StringUtil.Deserialize(br);
      this.W = br.ReadInt32();
      this.H = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Url, bw);
      StringUtil.Serialize(this.ThumbUrl, bw);
      StringUtil.Serialize(this.ContentUrl, bw);
      StringUtil.Serialize(this.ContentType, bw);
      bw.Write(this.W);
      bw.Write(this.H);
    }
  }
}
