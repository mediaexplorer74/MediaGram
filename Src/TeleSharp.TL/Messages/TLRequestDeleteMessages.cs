// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestDeleteMessages
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-443640366)]
  public class TLRequestDeleteMessages : TLMethod
  {
    public override int Constructor => -443640366;

    public int Flags { get; set; }

    public bool Revoke { get; set; }

    public TLVector<int> Id { get; set; }

    public TLAffectedMessages Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Revoke ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Revoke = (this.Flags & 1) != 0;
      this.Id = ObjectUtils.DeserializeVector<int>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAffectedMessages) ObjectUtils.DeserializeObject(br);
    }
  }
}
