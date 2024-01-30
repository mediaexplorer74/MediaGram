// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateChatAdmins
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1855224129)]
  public class TLUpdateChatAdmins : TLAbsUpdate
  {
    public override int Constructor => 1855224129;

    public int ChatId { get; set; }

    public bool Enabled { get; set; }

    public int Version { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ChatId = br.ReadInt32();
      this.Enabled = BoolUtil.Deserialize(br);
      this.Version = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChatId);
      BoolUtil.Serialize(this.Enabled, bw);
      bw.Write(this.Version);
    }
  }
}
