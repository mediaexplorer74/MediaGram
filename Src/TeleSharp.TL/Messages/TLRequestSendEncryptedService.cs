﻿// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestSendEncryptedService
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(852769188)]
  public class TLRequestSendEncryptedService : TLMethod
  {
    public override int Constructor => 852769188;

    public TLInputEncryptedChat Peer { get; set; }

    public long RandomId { get; set; }

    public byte[] Data { get; set; }

    public TLAbsSentEncryptedMessage Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Peer = (TLInputEncryptedChat) ObjectUtils.DeserializeObject(br);
      this.RandomId = br.ReadInt64();
      this.Data = BytesUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Peer, bw);
      bw.Write(this.RandomId);
      BytesUtil.Serialize(this.Data, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsSentEncryptedMessage) ObjectUtils.DeserializeObject(br);
    }
  }
}
