// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Auth.TLRequestBindTempAuthKey
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Auth
{
  [TLObject(-841733627)]
  public class TLRequestBindTempAuthKey : TLMethod
  {
    public override int Constructor => -841733627;

    public long PermAuthKeyId { get; set; }

    public long Nonce { get; set; }

    public int ExpiresAt { get; set; }

    public byte[] EncryptedMessage { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PermAuthKeyId = br.ReadInt64();
      this.Nonce = br.ReadInt64();
      this.ExpiresAt = br.ReadInt32();
      this.EncryptedMessage = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.PermAuthKeyId);
      bw.Write(this.Nonce);
      bw.Write(this.ExpiresAt);
      BytesUtil.Serialize(this.EncryptedMessage, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = BoolUtil.Deserialize(br);
    }
  }
}
