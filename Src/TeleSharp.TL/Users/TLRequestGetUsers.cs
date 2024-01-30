// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Users.TLRequestGetUsers
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Users
{
  [TLObject(227648840)]
  public class TLRequestGetUsers : TLMethod
  {
    public override int Constructor => 227648840;

    public TLVector<TLAbsInputUser> Id { get; set; }

    public TLVector<TLAbsUser> Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Id = ObjectUtils.DeserializeVector<TLAbsInputUser>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Id, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = ObjectUtils.DeserializeVector<TLAbsUser>(br);
    }
  }
}
