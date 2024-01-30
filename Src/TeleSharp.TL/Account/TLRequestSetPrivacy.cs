// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Account.TLRequestSetPrivacy
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Account
{
  [TLObject(-906486552)]
  public class TLRequestSetPrivacy : TLMethod
  {
    public override int Constructor => -906486552;

    public TLAbsInputPrivacyKey Key { get; set; }

    public TLVector<TLAbsInputPrivacyRule> Rules { get; set; }

    public TLPrivacyRules Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Key = (TLAbsInputPrivacyKey) ObjectUtils.DeserializeObject(br);
      this.Rules = ObjectUtils.DeserializeVector<TLAbsInputPrivacyRule>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Key, bw);
      ObjectUtils.SerializeObject((object) this.Rules, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLPrivacyRules) ObjectUtils.DeserializeObject(br);
    }
  }
}
