// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestUploadMedia
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(1369162417)]
  public class TLRequestUploadMedia : TLMethod
  {
    public override int Constructor => 1369162417;

    public TLAbsInputPeer Peer { get; set; }

    public TLAbsInputMedia Media { get; set; }

    public TLAbsMessageMedia Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLAbsInputPeer) ObjectUtils.DeserializeObject(br);
      this.Media = (TLAbsInputMedia) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      ObjectUtils.SerializeObject((object) this.Media, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsMessageMedia) ObjectUtils.DeserializeObject(br);
    }
  }
}
