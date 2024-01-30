// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateBotInlineQuery
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1417832080)]
  public class TLUpdateBotInlineQuery : TLAbsUpdate
  {
    public override int Constructor => 1417832080;

    public int Flags { get; set; }

    public long QueryId { get; set; }

    public int UserId { get; set; }

    public string Query { get; set; }

    public TLAbsGeoPoint Geo { get; set; }

    public string Offset { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Geo != null ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.QueryId = br.ReadInt64();
      this.UserId = br.ReadInt32();
      this.Query = StringUtil.Deserialize(br);
      this.Geo = (this.Flags & 1) == 0 ? (TLAbsGeoPoint) null : (TLAbsGeoPoint) ObjectUtils.DeserializeObject(br);
      this.Offset = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.QueryId);
      bw.Write(this.UserId);
      StringUtil.Serialize(this.Query, bw);
      if ((this.Flags & 1) != 0)
        ObjectUtils.SerializeObject((object) this.Geo, bw);
      StringUtil.Serialize(this.Offset, bw);
    }
  }
}
