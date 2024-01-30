﻿// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLMessageActionChannelMigrateFrom
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1336546578)]
  public class TLMessageActionChannelMigrateFrom : TLAbsMessageAction
  {
    public override int Constructor => -1336546578;

    public string Title { get; set; }

    public int ChatId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Title = StringUtil.Deserialize(br);
      this.ChatId = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Title, bw);
      bw.Write(this.ChatId);
    }
  }
}
