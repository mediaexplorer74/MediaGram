// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLReceivedNotifyMessage
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-1551583367)]
  public class TLReceivedNotifyMessage : TLObject
  {
    public override int Constructor => -1551583367;

    public int Id { get; set; }

    public int Flags { get; set; }

    public void ComputeFlags() => this.Flags = 0;

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = br.ReadInt32();
      this.Flags = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Id);
    }
  }
}
