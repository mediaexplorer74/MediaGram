// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputFile
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-181407105)]
  public class TLInputFile : TLAbsInputFile
  {
    public override int Constructor => -181407105;

    public long Id { get; set; }

    public int Parts { get; set; }

    public string Name { get; set; }

    public string Md5Checksum { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt64();
      this.Parts = br.ReadInt32();
      this.Name = StringUtil.Deserialize(br);
      this.Md5Checksum = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      bw.Write(this.Parts);
      StringUtil.Serialize(this.Name, bw);
      StringUtil.Serialize(this.Md5Checksum, bw);
    }
  }
}
