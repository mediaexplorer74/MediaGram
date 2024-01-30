// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLRequestInitConnection
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1769565673)]
  public class TLRequestInitConnection : TLMethod
  {
    public override int Constructor => 1769565673;

    public int ApiId { get; set; }

    public string DeviceModel { get; set; }

    public string SystemVersion { get; set; }

    public string AppVersion { get; set; }

    public string LangCode { get; set; }

    public TLObject Query { get; set; }

    public TLObject Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ApiId = br.ReadInt32();
      this.DeviceModel = StringUtil.Deserialize(br);
      this.SystemVersion = StringUtil.Deserialize(br);
      this.AppVersion = StringUtil.Deserialize(br);
      this.LangCode = StringUtil.Deserialize(br);
      this.Query = (TLObject) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ApiId);
      StringUtil.Serialize(this.DeviceModel, bw);
      StringUtil.Serialize(this.SystemVersion, bw);
      StringUtil.Serialize(this.AppVersion, bw);
      StringUtil.Serialize(this.LangCode, bw);
      ObjectUtils.SerializeObject((object) this.Query, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLObject) ObjectUtils.DeserializeObject(br);
    }
  }
}
