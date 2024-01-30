// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.Network.TcpMessage
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TLSharp.Core.MTProto.Crypto;

#nullable disable
namespace TLSharp.Core.Network
{
  public class TcpMessage
  {
    public int SequneceNumber { get; private set; }

    public byte[] Body { get; private set; }

    public TcpMessage(int seqNumber, byte[] body)
    {
      if (body == null)
        throw new ArgumentNullException(nameof (body));
      this.SequneceNumber = seqNumber;
      this.Body = body;
    }

    public byte[] Encode()
    {
      using (MemoryStream output = new MemoryStream())
      {
        using (BinaryWriter binaryWriter = new BinaryWriter((Stream) output))
        {
          binaryWriter.Write(this.Body.Length + 12);
          binaryWriter.Write(this.SequneceNumber);
          binaryWriter.Write(this.Body);
          byte[] array = ((IEnumerable<byte>) new Crc32().ComputeHash(output.GetBuffer(), 0, 8 + this.Body.Length)).Reverse<byte>().ToArray<byte>();
          binaryWriter.Write(array);
          return output.ToArray();
        }
      }
    }

    public static TcpMessage Decode(byte[] body)
    {
      if (body == null)
        throw new ArgumentNullException(nameof (body));
      if (body.Length < 12)
        throw new InvalidOperationException("Ops, wrong size of input packet");
      using (MemoryStream input = new MemoryStream(body))
      {
        using (BinaryReader binaryReader = new BinaryReader((Stream) input))
        {
          int num = binaryReader.ReadInt32();
          if (num < 12)
            throw new InvalidOperationException(string.Format("invalid packet length: {0}", (object) num));
          int seqNumber = binaryReader.ReadInt32();
          byte[] body1 = binaryReader.ReadBytes(num - 12);
          if (!((IEnumerable<byte>) binaryReader.ReadBytes(4)).SequenceEqual<byte>(((IEnumerable<byte>) new Crc32().ComputeHash(body, 0, num - 4)).Reverse<byte>()))
            throw new InvalidOperationException("invalid checksum! skip");
          return new TcpMessage(seqNumber, body1);
        }
      }
    }
  }
}
