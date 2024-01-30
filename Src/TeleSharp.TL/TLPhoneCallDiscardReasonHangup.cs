// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLPhoneCallDiscardReasonHangup
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1471006352)]
  public class TLPhoneCallDiscardReasonHangup : TLAbsPhoneCallDiscardReason
  {
    public override int Constructor => 1471006352;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
