// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLRequestInvokeAfterMsg
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-878758099)]
  public class TLRequestInvokeAfterMsg : TLMethod
  {
    public override int Constructor => -878758099;

    public long MsgId { get; set; }

    public TLObject Query { get; set; }

    public TLObject Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.MsgId = br.ReadInt64();
      this.Query = (TLObject) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.MsgId);
      ObjectUtils.SerializeObject((object) this.Query, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLObject) ObjectUtils.DeserializeObject(br);
    }
  }
}
