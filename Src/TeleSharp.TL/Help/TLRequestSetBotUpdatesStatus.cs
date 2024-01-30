// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Help.TLRequestSetBotUpdatesStatus
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Help
{
  [TLObject(-333262899)]
  public class TLRequestSetBotUpdatesStatus : TLMethod
  {
    public override int Constructor => -333262899;

    public int PendingUpdatesCount { get; set; }

    public string Message { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.PendingUpdatesCount = br.ReadInt32();
      this.Message = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.PendingUpdatesCount);
      StringUtil.Serialize(this.Message, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = BoolUtil.Deserialize(br);
    }
  }
}
