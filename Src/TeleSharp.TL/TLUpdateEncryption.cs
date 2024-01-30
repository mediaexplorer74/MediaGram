// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateEncryption
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1264392051)]
  public class TLUpdateEncryption : TLAbsUpdate
  {
    public override int Constructor => -1264392051;

    public TLAbsEncryptedChat Chat { get; set; }

    public int Date { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Chat = (TLAbsEncryptedChat) ObjectUtils.DeserializeObject(br);
      this.Date = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Chat, bw);
      bw.Write(this.Date);
    }
  }
}
