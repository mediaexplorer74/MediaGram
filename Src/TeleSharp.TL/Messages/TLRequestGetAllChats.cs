// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestGetAllChats
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-341307408)]
  public class TLRequestGetAllChats : TLMethod
  {
    public override int Constructor => -341307408;

    public TLVector<int> ExceptIds { get; set; }

    public TLAbsChats Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ExceptIds = ObjectUtils.DeserializeVector<int>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.ExceptIds, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsChats) ObjectUtils.DeserializeObject(br);
    }
  }
}
