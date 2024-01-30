// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestRequestEncryption
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-162681021)]
  public class TLRequestRequestEncryption : TLMethod
  {
    public override int Constructor => -162681021;

    public TLAbsInputUser UserId { get; set; }

    public int RandomId { get; set; }

    public byte[] GA { get; set; }

    public TLAbsEncryptedChat Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
      this.RandomId = br.ReadInt32();
      this.GA = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.UserId, bw);
      bw.Write(this.RandomId);
      BytesUtil.Serialize(this.GA, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsEncryptedChat) ObjectUtils.DeserializeObject(br);
    }
  }
}
