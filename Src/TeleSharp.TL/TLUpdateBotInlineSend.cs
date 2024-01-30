// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateBotInlineSend
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(239663460)]
  public class TLUpdateBotInlineSend : TLAbsUpdate
  {
    public override int Constructor => 239663460;

    public int Flags { get; set; }

    public int UserId { get; set; }

    public string Query { get; set; }

    public TLAbsGeoPoint Geo { get; set; }

    public string Id { get; set; }

    public TLInputBotInlineMessageID MsgId { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Geo != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.MsgId != null ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.UserId = br.ReadInt32();
      this.Query = StringUtil.Deserialize(br);
      this.Geo = (this.Flags & 1) == 0 ? (TLAbsGeoPoint) null : (TLAbsGeoPoint) ObjectUtils.DeserializeObject(br);
      this.Id = StringUtil.Deserialize(br);
      if ((this.Flags & 2) != 0)
        this.MsgId = (TLInputBotInlineMessageID) ObjectUtils.DeserializeObject(br);
      else
        this.MsgId = (TLInputBotInlineMessageID) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.UserId);
      StringUtil.Serialize(this.Query, bw);
      if ((this.Flags & 1) != 0)
        ObjectUtils.SerializeObject((object) this.Geo, bw);
      StringUtil.Serialize(this.Id, bw);
      if ((this.Flags & 2) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.MsgId, bw);
    }
  }
}
