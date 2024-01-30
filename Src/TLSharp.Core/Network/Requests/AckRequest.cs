// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.Network.Requests.AckRequest
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using System;
using System.Collections.Generic;
using System.IO;
using TeleSharp.TL;

#nullable disable
namespace TLSharp.Core.Network.Requests
{
  public class AckRequest : TLMethod
  {
    private readonly List<ulong> msgs;

    public AckRequest(List<ulong> msgs) => this.msgs = msgs;

    public override void SerializeBody(BinaryWriter writer)
    {
      writer.Write(1658238041);
      writer.Write(481674261);
      writer.Write(this.msgs.Count);
      foreach (ulong msg in this.msgs)
        writer.Write(msg);
    }

    public override void DeserializeBody(BinaryReader reader)
    {
      throw new NotImplementedException();
    }

    public override void DeserializeResponse(BinaryReader stream)
    {
      throw new NotImplementedException();
    }

    public override bool Confirmed => false;

    public override bool Responded { get; }

    public override int Constructor => 1658238041;
  }
}
