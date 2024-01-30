// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestSetEncryptedTyping
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(2031374829)]
  public class TLRequestSetEncryptedTyping : TLMethod
  {
    public override int Constructor => 2031374829;

    public TLInputEncryptedChat Peer { get; set; }

    public bool Typing { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLInputEncryptedChat) ObjectUtils.DeserializeObject(br);
      this.Typing = BoolUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      BoolUtil.Serialize(this.Typing, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = BoolUtil.Deserialize(br);
    }
  }
}
