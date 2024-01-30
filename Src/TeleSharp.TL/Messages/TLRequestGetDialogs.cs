// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestGetDialogs
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(421243333)]
  public class TLRequestGetDialogs : TLMethod
  {
    public override int Constructor => 421243333;

    public int Flags { get; set; }

    public bool ExcludePinned { get; set; }

    public int OffsetDate { get; set; }

    public int OffsetId { get; set; }

    public TLAbsInputPeer OffsetPeer { get; set; }

    public int Limit { get; set; }

    public TLAbsDialogs Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.ExcludePinned ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.ExcludePinned = (this.Flags & 1) != 0;
      this.OffsetDate = br.ReadInt32();
      this.OffsetId = br.ReadInt32();
      this.OffsetPeer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.Limit = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.OffsetDate);
      bw.Write(this.OffsetId);
      ObjectUtils.SerializeObject((object) this.OffsetPeer, bw);
      bw.Write(this.Limit);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsDialogs) ObjectUtils.DeserializeObject(br);
    }
  }
}
