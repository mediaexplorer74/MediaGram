// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Auth.TLRequestSendInvites
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Auth
{
  [TLObject(1998331287)]
  public class TLRequestSendInvites : TLMethod
  {
    public override int Constructor => 1998331287;

    public TLVector<string> PhoneNumbers { get; set; }

    public string Message { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PhoneNumbers = ObjectUtils.DeserializeVector<string>(br);
      this.Message = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.PhoneNumbers, bw);
      StringUtil.Serialize(this.Message, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = BoolUtil.Deserialize(br);
    }
  }
}
