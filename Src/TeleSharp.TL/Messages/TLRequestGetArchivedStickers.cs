// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestGetArchivedStickers
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(1475442322)]
  public class TLRequestGetArchivedStickers : TLMethod
  {
    public override int Constructor => 1475442322;

    public int Flags { get; set; }

    public bool Masks { get; set; }

    public long OffsetId { get; set; }

    public int Limit { get; set; }

    public TLArchivedStickers Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Masks ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Masks = (this.Flags & 1) != 0;
      this.OffsetId = br.ReadInt64();
      this.Limit = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.OffsetId);
      bw.Write(this.Limit);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLArchivedStickers) ObjectUtils.DeserializeObject(br);
    }
  }
}
