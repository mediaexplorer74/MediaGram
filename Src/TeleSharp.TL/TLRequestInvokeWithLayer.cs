// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLRequestInvokeWithLayer
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-627372787)]
  public class TLRequestInvokeWithLayer : TLMethod
  {
    public override int Constructor => -627372787;

    public int Layer { get; set; }

    public TLObject Query { get; set; }

    public TLObject Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Layer = br.ReadInt32();
      this.Query = (TLObject) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Layer);
      ObjectUtils.SerializeObject((object) this.Query, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLObject) ObjectUtils.DeserializeObject(br);
    }
  }
}
