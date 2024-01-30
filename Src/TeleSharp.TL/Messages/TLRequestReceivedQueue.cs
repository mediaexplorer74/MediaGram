// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestReceivedQueue
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(1436924774)]
  public class TLRequestReceivedQueue : TLMethod
  {
    public override int Constructor => 1436924774;

    public int MaxQts { get; set; }

    public TLVector<long> Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.MaxQts = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.MaxQts);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = ObjectUtils.DeserializeVector<long>(br);
    }
  }
}
