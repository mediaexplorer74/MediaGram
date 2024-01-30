// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Help.TLSupport
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Help
{
  [TLObject(398898678)]
  public class TLSupport : TLObject
  {
    public override int Constructor => 398898678;

    public string PhoneNumber { get; set; }

    public TLAbsUser User { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PhoneNumber = StringUtil.Deserialize(br);
      this.User = (TLAbsUser) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.PhoneNumber, bw);
      ObjectUtils.SerializeObject((object) this.User, bw);
    }
  }
}
