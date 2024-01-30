// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Bots.TLRequestSendCustomRequest
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Bots
{
  [TLObject(-1440257555)]
  public class TLRequestSendCustomRequest : TLMethod
  {
    public override int Constructor => -1440257555;

    public string CustomMethod { get; set; }

    public TLDataJSON Params { get; set; }

    public TLDataJSON Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.CustomMethod = StringUtil.Deserialize(br);
      this.Params = (TLDataJSON) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.CustomMethod, bw);
      ObjectUtils.SerializeObject((object) this.Params, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLDataJSON) ObjectUtils.DeserializeObject(br);
    }
  }
}
