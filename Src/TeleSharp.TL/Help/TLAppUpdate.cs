// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Help.TLAppUpdate
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Help
{
  [TLObject(-1987579119)]
  public class TLAppUpdate : TLAbsAppUpdate
  {
    public override int Constructor => -1987579119;

    public int Id { get; set; }

    public bool Critical { get; set; }

    public string Url { get; set; }

    public string Text { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt32();
      this.Critical = BoolUtil.Deserialize(br);
      this.Url = StringUtil.Deserialize(br);
      this.Text = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Id);
      BoolUtil.Serialize(this.Critical, bw);
      StringUtil.Serialize(this.Url, bw);
      StringUtil.Serialize(this.Text, bw);
    }
  }
}
