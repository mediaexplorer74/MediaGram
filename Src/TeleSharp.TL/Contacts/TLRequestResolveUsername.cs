// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Contacts.TLRequestResolveUsername
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Contacts
{
  [TLObject(-113456221)]
  public class TLRequestResolveUsername : TLMethod
  {
    public override int Constructor => -113456221;

    public string Username { get; set; }

    public TLResolvedPeer Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Username = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Username, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLResolvedPeer) ObjectUtils.DeserializeObject(br);
    }
  }
}
