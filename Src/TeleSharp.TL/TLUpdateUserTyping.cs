// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUpdateUserTyping
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1548249383)]
  public class TLUpdateUserTyping : TLAbsUpdate
  {
    public override int Constructor => 1548249383;

    public int UserId { get; set; }

    public TLAbsSendMessageAction Action { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.UserId = br.ReadInt32();
      this.Action = (TLAbsSendMessageAction) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.UserId);
      ObjectUtils.SerializeObject((object) this.Action, bw);
    }
  }
}
