// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestGetSavedGifs
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-2084618926)]
  public class TLRequestGetSavedGifs : TLMethod
  {
    public override int Constructor => -2084618926;

    public int Hash { get; set; }

    public TLAbsSavedGifs Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.Hash = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Hash);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsSavedGifs) ObjectUtils.DeserializeObject(br);
    }
  }
}
