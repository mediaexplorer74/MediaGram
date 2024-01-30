// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestSearchGifs
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-1080395925)]
  public class TLRequestSearchGifs : TLMethod
  {
    public override int Constructor => -1080395925;

    public string Q { get; set; }

    public int Offset { get; set; }

    public TLFoundGifs Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Q = StringUtil.Deserialize(br);
      this.Offset = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Q, bw);
      bw.Write(this.Offset);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLFoundGifs) ObjectUtils.DeserializeObject(br);
    }
  }
}
