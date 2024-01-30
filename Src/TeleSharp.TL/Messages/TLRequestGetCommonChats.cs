// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestGetCommonChats
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(218777796)]
  public class TLRequestGetCommonChats : TLMethod
  {
    public override int Constructor => 218777796;

    public TLAbsInputUser UserId { get; set; }

    public int MaxId { get; set; }

    public int Limit { get; set; }

    public TLAbsChats Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
      this.MaxId = br.ReadInt32();
      this.Limit = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.UserId, bw);
      bw.Write(this.MaxId);
      bw.Write(this.Limit);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsChats) ObjectUtils.DeserializeObject(br);
    }
  }
}
