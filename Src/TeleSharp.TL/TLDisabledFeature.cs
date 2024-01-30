// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLDisabledFeature
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1369215196)]
  public class TLDisabledFeature : TLObject
  {
    public override int Constructor => -1369215196;

    public string Feature { get; set; }

    public string Description { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Feature = StringUtil.Deserialize(br);
      this.Description = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Feature, bw);
      StringUtil.Serialize(this.Description, bw);
    }
  }
}
