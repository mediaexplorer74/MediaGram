// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLTopPeerCategoryCorrespondents
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(104314861)]
  public class TLTopPeerCategoryCorrespondents : TLAbsTopPeerCategory
  {
    public override int Constructor => 104314861;

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
    }

    public override void SerializeBody(BinaryWriter bw) => bw.Write(this.Constructor);
  }
}
