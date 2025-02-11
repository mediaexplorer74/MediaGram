﻿// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLChat
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-652419756)]
  public class TLChat : TLAbsChat
  {
    public override int Constructor => -652419756;

    public int Flags { get; set; }

    public bool Creator { get; set; }

    public bool Kicked { get; set; }

    public bool Left { get; set; }

    public bool AdminsEnabled { get; set; }

    public bool Admin { get; set; }

    public bool Deactivated { get; set; }

    public int Id { get; set; }

    public string Title { get; set; }

    public TLAbsChatPhoto Photo { get; set; }

    public int ParticipantsCount { get; set; }

    public int Date { get; set; }

    public int Version { get; set; }

    public TLAbsInputChannel MigratedTo { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Creator ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Kicked ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Left ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.AdminsEnabled ? this.Flags | 8 : this.Flags & -9;
      this.Flags = this.Admin ? this.Flags | 16 : this.Flags & -17;
      this.Flags = this.Deactivated ? this.Flags | 32 : this.Flags & -33;
      this.Flags = this.MigratedTo != null ? this.Flags | 64 : this.Flags & -65;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Creator = (this.Flags & 1) != 0;
      this.Kicked = (this.Flags & 2) != 0;
      this.Left = (this.Flags & 4) != 0;
      this.AdminsEnabled = (this.Flags & 8) != 0;
      this.Admin = (this.Flags & 16) != 0;
      this.Deactivated = (this.Flags & 32) != 0;
      this.Id = br.ReadInt32();
      this.Title = StringUtil.Deserialize(br);
      this.Photo = (TLAbsChatPhoto) ObjectUtils.DeserializeObject(br);
      this.ParticipantsCount = br.ReadInt32();
      this.Date = br.ReadInt32();
      this.Version = br.ReadInt32();
      if ((this.Flags & 64) != 0)
        this.MigratedTo = (TLAbsInputChannel) ObjectUtils.DeserializeObject(br);
      else
        this.MigratedTo = (TLAbsInputChannel) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Id);
      StringUtil.Serialize(this.Title, bw);
      ObjectUtils.SerializeObject((object) this.Photo, bw);
      bw.Write(this.ParticipantsCount);
      bw.Write(this.Date);
      bw.Write(this.Version);
      if ((this.Flags & 64) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.MigratedTo, bw);
    }
  }
}
