// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestAcceptEncryption
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(1035731989)]
  public class TLRequestAcceptEncryption : TLMethod
  {
    public override int Constructor => 1035731989;

    public TLInputEncryptedChat Peer { get; set; }

    public byte[] GB { get; set; }

    public long KeyFingerprint { get; set; }

    public TLAbsEncryptedChat Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLInputEncryptedChat) ObjectUtils.DeserializeObject(br);
      this.GB = BytesUtil.Deserialize(br);
      this.KeyFingerprint = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      BytesUtil.Serialize(this.GB, bw);
      bw.Write(this.KeyFingerprint);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsEncryptedChat) ObjectUtils.DeserializeObject(br);
    }
  }
}
