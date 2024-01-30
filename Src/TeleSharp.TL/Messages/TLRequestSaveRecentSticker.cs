// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestSaveRecentSticker
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(958863608)]
  public class TLRequestSaveRecentSticker : TLMethod
  {
    public override int Constructor => 958863608;

    public int Flags { get; set; }

    public bool Attached { get; set; }

    public TLAbsInputDocument Id { get; set; }

    public bool Unsave { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Attached ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Attached = (this.Flags & 1) != 0;
      this.Id = (TLAbsInputDocument) ObjectUtils.DeserializeObject(br);
      this.Unsave = BoolUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Id, bw);
      BoolUtil.Serialize(this.Unsave, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = BoolUtil.Deserialize(br);
    }
  }
}
