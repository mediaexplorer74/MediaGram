// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Auth.TLCheckedPhone
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Auth
{
  [TLObject(-2128698738)]
  public class TLCheckedPhone : TLObject
  {
    public override int Constructor => -2128698738;

    public bool PhoneRegistered { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PhoneRegistered = BoolUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      BoolUtil.Serialize(this.PhoneRegistered, bw);
    }
  }
}
