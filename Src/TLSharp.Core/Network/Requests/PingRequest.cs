// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.Network.Requests.PingRequest
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using System;
using System.IO;
using TeleSharp.TL;
using TLSharp.Core.Utils;

#nullable disable
namespace TLSharp.Core.Network.Requests
{
  public class PingRequest : TLMethod
  {
    public override void SerializeBody(BinaryWriter writer)
    {
      writer.Write(this.Constructor);
      writer.Write(Helpers.GenerateRandomLong());
    }

    public override void DeserializeBody(BinaryReader reader)
    {
      throw new NotImplementedException();
    }

    public override void DeserializeResponse(BinaryReader stream)
    {
      throw new NotImplementedException();
    }

    public override int Constructor => 2059302892;
  }
}
