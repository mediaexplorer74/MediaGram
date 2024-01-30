// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputAppEvent
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(1996904104)]
  public class TLInputAppEvent : TLObject
  {
    public override int Constructor => 1996904104;

    public double Time { get; set; }

    public string Type { get; set; }

    public long Peer { get; set; }

    public string Data { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Time = br.ReadDouble();
      this.Type = StringUtil.Deserialize(br);
      this.Peer = br.ReadInt64();
      this.Data = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.Time);
      StringUtil.Serialize(this.Type, bw);
      bw.Write(this.Peer);
      StringUtil.Serialize(this.Data, bw);
    }
  }
}
