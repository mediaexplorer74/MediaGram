// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Channels.TLRequestUpdatePinnedMessage
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Channels
{
  [TLObject(-1490162350)]
  public class TLRequestUpdatePinnedMessage : TLMethod
  {
    public override int Constructor => -1490162350;

    public int Flags { get; set; }

    public bool Silent { get; set; }

    public TLAbsInputChannel Channel { get; set; }

    public int Id { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Silent ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Silent = (this.Flags & 1) != 0;
      this.Channel = (TLAbsInputChannel) ObjectUtils.DeserializeObject(br);
      this.Id = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Channel, bw);
      bw.Write(this.Id);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
    }
  }
}
