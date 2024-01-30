// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLBotCallbackAnswer
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(911761060)]
  public class TLBotCallbackAnswer : TLObject
  {
    public override int Constructor => 911761060;

    public int Flags { get; set; }

    public bool Alert { get; set; }

    public bool HasUrl { get; set; }

    public string Message { get; set; }

    public string Url { get; set; }

    public int CacheTime { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Alert ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.HasUrl ? this.Flags | 8 : this.Flags & -9;
      this.Flags = this.Message != null ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Url != null ? this.Flags | 4 : this.Flags & -5;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Alert = (this.Flags & 2) != 0;
      this.HasUrl = (this.Flags & 8) != 0;
      this.Message = (this.Flags & 1) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.Url = (this.Flags & 4) == 0 ? (string) null : StringUtil.Deserialize(br);
      this.CacheTime = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      if ((this.Flags & 1) != 0)
        StringUtil.Serialize(this.Message, bw);
      if ((this.Flags & 4) != 0)
        StringUtil.Serialize(this.Url, bw);
      bw.Write(this.CacheTime);
    }
  }
}
