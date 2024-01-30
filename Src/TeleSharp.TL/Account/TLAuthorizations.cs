// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Account.TLAuthorizations
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Account
{
  [TLObject(307276766)]
  public class TLAuthorizations : TLObject
  {
    public override int Constructor => 307276766;

    public TLVector<TLAuthorization> Authorizations { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Authorizations = ObjectUtils.DeserializeVector<TLAuthorization>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Authorizations, bw);
    }
  }
}
