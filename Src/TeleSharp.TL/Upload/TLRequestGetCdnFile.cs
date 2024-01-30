// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Upload.TLRequestGetCdnFile
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Upload
{
  [TLObject(536919235)]
  public class TLRequestGetCdnFile : TLMethod
  {
    public override int Constructor => 536919235;

    public byte[] FileToken { get; set; }

    public int Offset { get; set; }

    public int Limit { get; set; }

    public TLAbsCdnFile Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.FileToken = BytesUtil.Deserialize(br);
      this.Offset = br.ReadInt32();
      this.Limit = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BytesUtil.Serialize(this.FileToken, bw);
      bw.Write(this.Offset);
      bw.Write(this.Limit);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsCdnFile) ObjectUtils.DeserializeObject(br);
    }
  }
}
