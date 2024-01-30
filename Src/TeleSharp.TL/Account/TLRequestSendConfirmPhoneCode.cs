// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Account.TLRequestSendConfirmPhoneCode
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;
using TeleSharp.TL.Auth;

#nullable disable
namespace TeleSharp.TL.Account
{
  [TLObject(353818557)]
  public class TLRequestSendConfirmPhoneCode : TLMethod
  {
    public override int Constructor => 353818557;

    public int Flags { get; set; }

    public bool AllowFlashcall { get; set; }

    public string Hash { get; set; }

    public bool? CurrentNumber { get; set; }

    public TLSentCode Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.AllowFlashcall ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.CurrentNumber.HasValue ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.AllowFlashcall = (this.Flags & 1) != 0;
      this.Hash = StringUtil.Deserialize(br);
      if ((this.Flags & 1) != 0)
        this.CurrentNumber = new bool?(BoolUtil.Deserialize(br));
      else
        this.CurrentNumber = new bool?();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      StringUtil.Serialize(this.Hash, bw);
      if ((this.Flags & 1) == 0)
        return;
      BoolUtil.Serialize(this.CurrentNumber.Value, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLSentCode) ObjectUtils.DeserializeObject(br);
    }
  }
}
