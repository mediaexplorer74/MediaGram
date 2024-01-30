// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Users.TLRequestGetFullUser
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Users
{
  [TLObject(-902781519)]
  public class TLRequestGetFullUser : TLMethod
  {
    public override int Constructor => -902781519;

    public TLAbsInputUser Id { get; set; }

    public TLUserFull Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLUserFull) ObjectUtils.DeserializeObject(br);
    }
  }
}
