// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLError
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-994444869)]
  public class TLError : TLObject
  {
    public override int Constructor => -994444869;

    public int Code { get; set; }

    public string Text { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Code = br.ReadInt32();
      this.Text = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Code);
      StringUtil.Serialize(this.Text, bw);
    }
  }
}
