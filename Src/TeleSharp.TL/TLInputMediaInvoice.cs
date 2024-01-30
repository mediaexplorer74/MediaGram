// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputMediaInvoice
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1844103547)]
  public class TLInputMediaInvoice : TLAbsInputMedia
  {
    public override int Constructor => -1844103547;

    public int Flags { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public TLInputWebDocument Photo { get; set; }

    public TLInvoice Invoice { get; set; }

    public byte[] Payload { get; set; }

    public string Provider { get; set; }

    public string StartParam { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Photo != null ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Title = StringUtil.Deserialize(br);
      this.Description = StringUtil.Deserialize(br);
      this.Photo = (this.Flags & 1) == 0 ? (TLInputWebDocument) null : (TLInputWebDocument) ObjectUtils.DeserializeObject(br);
      this.Invoice = (TLInvoice) ObjectUtils.DeserializeObject(br);
      this.Payload = BytesUtil.Deserialize(br);
      this.Provider = StringUtil.Deserialize(br);
      this.StartParam = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      StringUtil.Serialize(this.Title, bw);
      StringUtil.Serialize(this.Description, bw);
      if ((this.Flags & 1) != 0)
        ObjectUtils.SerializeObject((object) this.Photo, bw);
      ObjectUtils.SerializeObject((object) this.Invoice, bw);
      BytesUtil.Serialize(this.Payload, bw);
      StringUtil.Serialize(this.Provider, bw);
      StringUtil.Serialize(this.StartParam, bw);
    }
  }
}
