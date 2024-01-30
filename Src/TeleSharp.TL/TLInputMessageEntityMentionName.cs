// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputMessageEntityMentionName
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(546203849)]
  public class TLInputMessageEntityMentionName : TLAbsMessageEntity
  {
    public override int Constructor => 546203849;

    public int Offset { get; set; }

    public int Length { get; set; }

    public TLAbsInputUser UserId { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Offset = br.ReadInt32();
      this.Length = br.ReadInt32();
      this.UserId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Offset);
      bw.Write(this.Length);
      ObjectUtils.SerializeObject((object) this.UserId, bw);
    }
  }
}
