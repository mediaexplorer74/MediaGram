// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputMediaVenue
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(673687578)]
  public class TLInputMediaVenue : TLAbsInputMedia
  {
    public override int Constructor => 673687578;

    public TLAbsInputGeoPoint GeoPoint { get; set; }

    public string Title { get; set; }

    public string Address { get; set; }

    public string Provider { get; set; }

    public string VenueId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.GeoPoint = (TLAbsInputGeoPoint) ObjectUtils.DeserializeObject(br);
      this.Title = StringUtil.Deserialize(br);
      this.Address = StringUtil.Deserialize(br);
      this.Provider = StringUtil.Deserialize(br);
      this.VenueId = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.GeoPoint, bw);
      StringUtil.Serialize(this.Title, bw);
      StringUtil.Serialize(this.Address, bw);
      StringUtil.Serialize(this.Provider, bw);
      StringUtil.Serialize(this.VenueId, bw);
    }
  }
}
