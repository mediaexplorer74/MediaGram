﻿// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateChatParticipants
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(125178264)]
  public class TLUpdateChatParticipants : TLAbsUpdate
  {
    public override int Constructor => 125178264;

    public TLAbsChatParticipants Participants { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Participants = (TLAbsChatParticipants) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Participants, bw);
    }
  }
}
