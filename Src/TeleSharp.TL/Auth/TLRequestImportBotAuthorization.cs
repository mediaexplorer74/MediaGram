// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Auth.TLRequestImportBotAuthorization
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Auth
{
  [TLObject(1738800940)]
  public class TLRequestImportBotAuthorization : TLMethod
  {
    public override int Constructor => 1738800940;

    public int Flags { get; set; }

    public int ApiId { get; set; }

    public string ApiHash { get; set; }

    public string BotAuthToken { get; set; }

    public TLAuthorization Response { get; set; }

    public void ComputeFlags() => this.Flags = 0;

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.ApiId = br.ReadInt32();
      this.ApiHash = StringUtil.Deserialize(br);
      this.BotAuthToken = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.ApiId);
      StringUtil.Serialize(this.ApiHash, bw);
      StringUtil.Serialize(this.BotAuthToken, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAuthorization) ObjectUtils.DeserializeObject(br);
    }
  }
}
