// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Bots.TLRequestAnswerWebhookJSONQuery
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Bots
{
  [TLObject(-434028723)]
  public class TLRequestAnswerWebhookJSONQuery : TLMethod
  {
    public override int Constructor => -434028723;

    public long QueryId { get; set; }

    public TLDataJSON Data { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.QueryId = br.ReadInt64();
      this.Data = (TLDataJSON) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.QueryId);
      ObjectUtils.SerializeObject((object) this.Data, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = BoolUtil.Deserialize(br);
    }
  }
}
