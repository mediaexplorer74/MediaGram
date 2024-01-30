// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLUserStatusOnline
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-306628279)]
  public class TLUserStatusOnline : TLAbsUserStatus
  {
    public override int Constructor => -306628279;

    public int Expires { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Expires = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Expires);
    }
  }
}
