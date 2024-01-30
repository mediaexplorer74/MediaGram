// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Auth.TLSentCode
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Auth
{
  [TLObject(1577067778)]
  public class TLSentCode : TLObject
  {
    public override int Constructor => 1577067778;

    public int Flags { get; set; }

    public bool PhoneRegistered { get; set; }

    public TLAbsSentCodeType Type { get; set; }

    public string PhoneCodeHash { get; set; }

    public TLAbsCodeType NextType { get; set; }

    public int? Timeout { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.PhoneRegistered ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.NextType != null ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Timeout.HasValue ? this.Flags | 4 : this.Flags & -5;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.PhoneRegistered = (this.Flags & 1) != 0;
      this.Type = (TLAbsSentCodeType) ObjectUtils.DeserializeObject(br);
      this.PhoneCodeHash = StringUtil.Deserialize(br);
      this.NextType = (this.Flags & 2) == 0 ? (TLAbsCodeType) null : (TLAbsCodeType) ObjectUtils.DeserializeObject(br);
      if ((this.Flags & 4) != 0)
        this.Timeout = new int?(br.ReadInt32());
      else
        this.Timeout = new int?();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Type, bw);
      StringUtil.Serialize(this.PhoneCodeHash, bw);
      if ((this.Flags & 2) != 0)
        ObjectUtils.SerializeObject((object) this.NextType, bw);
      if ((this.Flags & 4) == 0)
        return;
      bw.Write(this.Timeout.Value);
    }
  }
}
