// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLPaymentSavedCredentialsCard
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-842892769)]
  public class TLPaymentSavedCredentialsCard : TLObject
  {
    public override int Constructor => -842892769;

    public string Id { get; set; }

    public string Title { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = StringUtil.Deserialize(br);
      this.Title = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Id, bw);
      StringUtil.Serialize(this.Title, bw);
    }
  }
}
