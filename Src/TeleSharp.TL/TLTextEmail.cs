// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLTextEmail
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-564523562)]
  public class TLTextEmail : TLAbsRichText
  {
    public override int Constructor => -564523562;

    public TLAbsRichText Text { get; set; }

    public string Email { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Text = (TLAbsRichText) ObjectUtils.DeserializeObject(br);
      this.Email = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Text, bw);
      StringUtil.Serialize(this.Email, bw);
    }
  }
}
