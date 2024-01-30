// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Account.TLRequestGetPrivacy
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Account
{
  [TLObject(-623130288)]
  public class TLRequestGetPrivacy : TLMethod
  {
    public override int Constructor => -623130288;

    public TLAbsInputPrivacyKey Key { get; set; }

    public TLPrivacyRules Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Key = (TLAbsInputPrivacyKey) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Key, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLPrivacyRules) ObjectUtils.DeserializeObject(br);
    }
  }
}
