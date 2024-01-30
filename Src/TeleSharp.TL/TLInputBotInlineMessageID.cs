// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputBotInlineMessageID
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1995686519)]
  public class TLInputBotInlineMessageID : TLObject
  {
    public override int Constructor => -1995686519;

    public int DcId { get; set; }

    public long Id { get; set; }

    public long AccessHash { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.DcId = br.ReadInt32();
      this.Id = br.ReadInt64();
      this.AccessHash = br.ReadInt64();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.DcId);
      bw.Write(this.Id);
      bw.Write(this.AccessHash);
    }
  }
}
