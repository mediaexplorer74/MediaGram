// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Photos.TLRequestGetUserPhotos
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Photos
{
  [TLObject(-1848823128)]
  public class TLRequestGetUserPhotos : TLMethod
  {
    public override int Constructor => -1848823128;

    public TLAbsInputUser UserId { get; set; }

    public int Offset { get; set; }

    public long MaxId { get; set; }

    public int Limit { get; set; }

    public TLAbsPhotos Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
      this.Offset = br.ReadInt32();
      this.MaxId = br.ReadInt64();
      this.Limit = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.UserId, bw);
      bw.Write(this.Offset);
      bw.Write(this.MaxId);
      bw.Write(this.Limit);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsPhotos) ObjectUtils.DeserializeObject(br);
    }
  }
}
