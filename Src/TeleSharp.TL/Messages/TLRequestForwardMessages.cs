// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestForwardMessages
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(1888354709)]
  public class TLRequestForwardMessages : TLMethod
  {
    public override int Constructor => 1888354709;

    public int Flags { get; set; }

    public bool Silent { get; set; }

    public bool Background { get; set; }

    public bool WithMyScore { get; set; }

    public TLAbsInputPeer FromPeer { get; set; }

    public TLVector<int> Id { get; set; }

    public TLVector<long> RandomId { get; set; }

    public TLAbsInputPeer ToPeer { get; set; }

    public TLAbsUpdates Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Silent ? this.Flags | 32 : this.Flags & -33;
      this.Flags = this.Background ? this.Flags | 64 : this.Flags & -65;
      this.Flags = this.WithMyScore ? this.Flags | 256 : this.Flags & -257;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Silent = (this.Flags & 32) != 0;
      this.Background = (this.Flags & 64) != 0;
      this.WithMyScore = (this.Flags & 256) != 0;
      this.FromPeer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.Id = ObjectUtils.DeserializeVector<int>(br);
      this.RandomId = ObjectUtils.DeserializeVector<long>(br);
      this.ToPeer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.FromPeer, bw);
      ObjectUtils.SerializeObject((object) this.Id, bw);
      ObjectUtils.SerializeObject((object) this.RandomId, bw);
      ObjectUtils.SerializeObject((object) this.ToPeer, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsUpdates) ObjectUtils.DeserializeObject(br);
    }
  }
}
