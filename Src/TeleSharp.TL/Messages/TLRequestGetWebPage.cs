// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestGetWebPage
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(852135825)]
  public class TLRequestGetWebPage : TLMethod
  {
    public override int Constructor => 852135825;

    public string Url { get; set; }

    public int Hash { get; set; }

    public TLAbsWebPage Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Url = StringUtil.Deserialize(br);
      this.Hash = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Url, bw);
      bw.Write(this.Hash);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsWebPage) ObjectUtils.DeserializeObject(br);
    }
  }
}
