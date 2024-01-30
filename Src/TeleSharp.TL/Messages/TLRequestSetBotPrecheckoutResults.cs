// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestSetBotPrecheckoutResults
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(163765653)]
  public class TLRequestSetBotPrecheckoutResults : TLMethod
  {
    public override int Constructor => 163765653;

    public int Flags { get; set; }

    public bool Success { get; set; }

    public long QueryId { get; set; }

    public string Error { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Success ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Error != null ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Success = (this.Flags & 2) != 0;
      this.QueryId = br.ReadInt64();
      if ((this.Flags & 1) != 0)
        this.Error = StringUtil.Deserialize(br);
      else
        this.Error = (string) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.QueryId);
      if ((this.Flags & 1) == 0)
        return;
      StringUtil.Serialize(this.Error, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = BoolUtil.Deserialize(br);
    }
  }
}
