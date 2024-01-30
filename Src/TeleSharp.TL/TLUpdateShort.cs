// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateShort
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(2027216577)]
  public class TLUpdateShort : TLAbsUpdates
  {
    public override int Constructor => 2027216577;

    public TLAbsUpdate Update { get; set; }

    public int Date { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Update = (TLAbsUpdate) ObjectUtils.DeserializeObject(br);
      this.Date = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Update, bw);
      bw.Write(this.Date);
    }
  }
}
