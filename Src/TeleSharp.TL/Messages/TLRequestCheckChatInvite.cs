// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestCheckChatInvite
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(1051570619)]
  public class TLRequestCheckChatInvite : TLMethod
  {
    public override int Constructor => 1051570619;

    public string Hash { get; set; }

    public TLAbsChatInvite Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Hash = StringUtil.Deserialize(br);

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Hash, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsChatInvite) ObjectUtils.DeserializeObject(br);
    }
  }
}
