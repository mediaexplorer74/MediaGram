// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Upload.TLRequestGetFile
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Upload
{
  [TLObject(-475607115)]
  public class TLRequestGetFile : TLMethod
  {
    public override int Constructor => -475607115;

    public TLAbsInputFileLocation Location { get; set; }

    public int Offset { get; set; }

    public int Limit { get; set; }

    public TLAbsFile Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Location = (TLAbsInputFileLocation) ObjectUtils.DeserializeObject(br);
      this.Offset = br.ReadInt32();
      this.Limit = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Location, bw);
      bw.Write(this.Offset);
      bw.Write(this.Limit);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsFile) ObjectUtils.DeserializeObject(br);
    }
  }
}
