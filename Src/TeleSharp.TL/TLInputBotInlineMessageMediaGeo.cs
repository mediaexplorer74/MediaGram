// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputBotInlineMessageMediaGeo
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-190472735)]
  public class TLInputBotInlineMessageMediaGeo : TLAbsInputBotInlineMessage
  {
    public override int Constructor => -190472735;

    public int Flags { get; set; }

    public TLAbsInputGeoPoint GeoPoint { get; set; }

    public TLAbsReplyMarkup ReplyMarkup { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.ReplyMarkup != null ? this.Flags | 4 : this.Flags & -5;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.GeoPoint = (TLAbsInputGeoPoint) ObjectUtils.DeserializeObject(br);
      if ((this.Flags & 4) != 0)
        this.ReplyMarkup = (TLAbsReplyMarkup) ObjectUtils.DeserializeObject(br);
      else
        this.ReplyMarkup = (TLAbsReplyMarkup) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.GeoPoint, bw);
      if ((this.Flags & 4) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.ReplyMarkup, bw);
    }
  }
}
