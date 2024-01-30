// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLLabeledPrice
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-886477832)]
  public class TLLabeledPrice : TLObject
  {
    public override int Constructor => -886477832;

    public string Label { get; set; }

    public long Amount { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Label = StringUtil.Deserialize(br);
      this.Amount = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Label, bw);
      bw.Write(this.Amount);
    }
  }
}
