﻿// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Photos.TLPhotos
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Photos
{
  [TLObject(-1916114267)]
  public class TLPhotos : TLAbsPhotos
  {
    public override int Constructor => -1916114267;

    public TLVector<TLAbsPhoto> Photos { get; set; }

    public TLVector<TLAbsUser> Users { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Photos = ObjectUtils.DeserializeVector<TLAbsPhoto>(br);
      this.Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Photos, bw);
      ObjectUtils.SerializeObject((object) this.Users, bw);
    }
  }
}
