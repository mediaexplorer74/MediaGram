// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLNearestDc
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1910892683)]
  public class TLNearestDc : TLObject
  {
    public override int Constructor => -1910892683;

    public string Country { get; set; }

    public int ThisDc { get; set; }

    public int NearestDc { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Country = StringUtil.Deserialize(br);
      this.ThisDc = br.ReadInt32();
      this.NearestDc = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Country, bw);
      bw.Write(this.ThisDc);
      bw.Write(this.NearestDc);
    }
  }
}
