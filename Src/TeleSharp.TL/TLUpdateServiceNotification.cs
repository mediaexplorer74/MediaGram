// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateServiceNotification
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-337352679)]
  public class TLUpdateServiceNotification : TLAbsUpdate
  {
    public override int Constructor => -337352679;

    public int Flags { get; set; }

    public bool Popup { get; set; }

    public int? InboxDate { get; set; }

    public string Type { get; set; }

    public string Message { get; set; }

    public TLAbsMessageMedia Media { get; set; }

    public TLVector<TLAbsMessageEntity> Entities { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Popup ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.InboxDate.HasValue ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Popup = (this.Flags & 1) != 0;
      this.InboxDate = (this.Flags & 2) == 0 ? new int?() : new int?(br.ReadInt32());
      this.Type = StringUtil.Deserialize(br);
      this.Message = StringUtil.Deserialize(br);
      this.Media = (TLAbsMessageMedia) ObjectUtils.DeserializeObject(br);
      this.Entities = ObjectUtils.DeserializeVector<TLAbsMessageEntity>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      if ((this.Flags & 2) != 0)
        bw.Write(this.InboxDate.Value);
      StringUtil.Serialize(this.Type, bw);
      StringUtil.Serialize(this.Message, bw);
      ObjectUtils.SerializeObject((object) this.Media, bw);
      ObjectUtils.SerializeObject((object) this.Entities, bw);
    }
  }
}
