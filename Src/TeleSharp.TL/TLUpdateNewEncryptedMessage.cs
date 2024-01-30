// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateNewEncryptedMessage
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(314359194)]
  public class TLUpdateNewEncryptedMessage : TLAbsUpdate
  {
    public override int Constructor => 314359194;

    public TLAbsEncryptedMessage Message { get; set; }

    public int Qts { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Message = (TLAbsEncryptedMessage) ObjectUtils.DeserializeObject(br);
      this.Qts = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Message, bw);
      bw.Write(this.Qts);
    }
  }
}
