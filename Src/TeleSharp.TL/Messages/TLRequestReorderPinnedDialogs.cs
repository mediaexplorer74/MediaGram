// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestReorderPinnedDialogs
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-1784678844)]
  public class TLRequestReorderPinnedDialogs : TLMethod
  {
    public override int Constructor => -1784678844;

    public int Flags { get; set; }

    public bool Force { get; set; }

    public TLVector<TLAbsInputPeer> Order { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Force ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Force = (this.Flags & 1) != 0;
      this.Order = ObjectUtils.DeserializeVector<TLAbsInputPeer>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Order, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = BoolUtil.Deserialize(br);
    }
  }
}
