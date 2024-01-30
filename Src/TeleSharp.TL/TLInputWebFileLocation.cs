// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputWebFileLocation
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1036396922)]
  public class TLInputWebFileLocation : TLObject
  {
    public override int Constructor => -1036396922;

    public string Url { get; set; }

    public long AccessHash { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Url = StringUtil.Deserialize(br);
      this.AccessHash = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Url, bw);
      bw.Write(this.AccessHash);
    }
  }
}
