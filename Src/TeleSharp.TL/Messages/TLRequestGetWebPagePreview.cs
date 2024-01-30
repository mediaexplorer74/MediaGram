// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestGetWebPagePreview
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(623001124)]
  public class TLRequestGetWebPagePreview : TLMethod
  {
    public override int Constructor => 623001124;

    public string Message { get; set; }

    public TLAbsMessageMedia Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Message = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Message, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsMessageMedia) ObjectUtils.DeserializeObject(br);
    }
  }
}
