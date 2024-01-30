// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestGetRecentStickers
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(1587647177)]
  public class TLRequestGetRecentStickers : TLMethod
  {
    public override int Constructor => 1587647177;

    public int Flags { get; set; }

    public bool Attached { get; set; }

    public int Hash { get; set; }

    public TLAbsRecentStickers Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Attached ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Attached = (this.Flags & 1) != 0;
      this.Hash = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Hash);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsRecentStickers) ObjectUtils.DeserializeObject(br);
    }
  }
}
