// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestExportChatInvite
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(2106086025)]
  public class TLRequestExportChatInvite : TLMethod
  {
    public override int Constructor => 2106086025;

    public int ChatId { get; set; }

    public TLAbsExportedChatInvite Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br) => this.ChatId = br.ReadInt32();

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      bw.Write(this.ChatId);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsExportedChatInvite) ObjectUtils.DeserializeObject(br);
    }
  }
}
