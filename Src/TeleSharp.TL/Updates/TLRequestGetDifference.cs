﻿// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Updates.TLRequestGetDifference
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Updates
{
  [TLObject(630429265)]
  public class TLRequestGetDifference : TLMethod
  {
    public override int Constructor => 630429265;

    public int Flags { get; set; }

    public int Pts { get; set; }

    public int? PtsTotalLimit { get; set; }

    public int Date { get; set; }

    public int Qts { get; set; }

    public TLAbsDifference Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.PtsTotalLimit.HasValue ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Pts = br.ReadInt32();
      this.PtsTotalLimit = (this.Flags & 1) == 0 ? new int?() : new int?(br.ReadInt32());
      this.Date = br.ReadInt32();
      this.Qts = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Pts);
      if ((this.Flags & 1) != 0)
        bw.Write(this.PtsTotalLimit.Value);
      bw.Write(this.Date);
      bw.Write(this.Qts);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsDifference) ObjectUtils.DeserializeObject(br);
    }
  }
}
