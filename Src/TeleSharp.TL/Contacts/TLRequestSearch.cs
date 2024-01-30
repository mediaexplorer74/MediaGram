// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Contacts.TLRequestSearch
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Contacts
{
  [TLObject(301470424)]
  public class TLRequestSearch : TLMethod
  {
    public override int Constructor => 301470424;

    public string Q { get; set; }

    public int Limit { get; set; }

    public TLFound Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Q = StringUtil.Deserialize(br);
      this.Limit = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      StringUtil.Serialize(this.Q, bw);
      bw.Write(this.Limit);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLFound) ObjectUtils.DeserializeObject(br);
    }
  }
}
