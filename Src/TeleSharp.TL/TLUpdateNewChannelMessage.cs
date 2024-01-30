// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateNewChannelMessage
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1656358105)]
  public class TLUpdateNewChannelMessage : TLAbsUpdate
  {
    public override int Constructor => 1656358105;

    public TLAbsMessage Message { get; set; }

    public int Pts { get; set; }

    public int PtsCount { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Message = (TLAbsMessage) ObjectUtils.DeserializeObject(br);
      this.Pts = br.ReadInt32();
      this.PtsCount = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Message, bw);
      bw.Write(this.Pts);
      bw.Write(this.PtsCount);
    }
  }
}
