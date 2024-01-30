// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLPostAddress
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(512535275)]
  public class TLPostAddress : TLObject
  {
    public override int Constructor => 512535275;

    public string StreetLine1 { get; set; }

    public string StreetLine2 { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string CountryIso2 { get; set; }

    public string PostCode { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.StreetLine1 = StringUtil.Deserialize(br);
      this.StreetLine2 = StringUtil.Deserialize(br);
      this.City = StringUtil.Deserialize(br);
      this.State = StringUtil.Deserialize(br);
      this.CountryIso2 = StringUtil.Deserialize(br);
      this.PostCode = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.StreetLine1, bw);
      StringUtil.Serialize(this.StreetLine2, bw);
      StringUtil.Serialize(this.City, bw);
      StringUtil.Serialize(this.State, bw);
      StringUtil.Serialize(this.CountryIso2, bw);
      StringUtil.Serialize(this.PostCode, bw);
    }
  }
}
