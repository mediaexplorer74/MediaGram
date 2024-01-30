// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.Network.MtProtoPlainSender
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace TLSharp.Core.Network
{
  public class MtProtoPlainSender
  {
    private int timeOffset;
    private long lastMessageId;
    private Random random;
    private TcpTransport transport;

    public MtProtoPlainSender(TcpTransport transport)
    {
      this.transport = transport;
      this.random = new Random();
    }

    public async Task Send(byte[] data, CancellationToken token = default (CancellationToken))
    {
      token.ThrowIfCancellationRequested();
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (BinaryWriter binaryWriter = new BinaryWriter((Stream) memoryStream))
        {
          binaryWriter.Write(0L);
          binaryWriter.Write(this.GetNewMessageId());
          binaryWriter.Write(data.Length);
          binaryWriter.Write(data);
          byte[] packet = memoryStream.ToArray();
          await this.transport.Send(packet, token).ConfigureAwait(false);
          packet = (byte[]) null;
        }
      }
    }

    public async Task<byte[]> Receive(CancellationToken token = default (CancellationToken))
    {
      token.ThrowIfCancellationRequested();
      TcpMessage result = await this.transport.Receive(token).ConfigureAwait(false);
      byte[] numArray;
      using (MemoryStream memoryStream = new MemoryStream(result.Body))
      {
        using (BinaryReader binaryReader = new BinaryReader((Stream) memoryStream))
        {
          long authKeyid = binaryReader.ReadInt64();
          long messageId = binaryReader.ReadInt64();
          int messageLength = binaryReader.ReadInt32();
          numArray = binaryReader.ReadBytes(messageLength);
        }
      }
      return numArray;
    }

    private long GetNewMessageId()
    {
      long int64 = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds);
      long newMessageId = int64 / 1000L + (long) this.timeOffset << 32 | int64 % 1000L << 22 | (long) (this.random.Next(524288) << 2);
      if (this.lastMessageId >= newMessageId)
        newMessageId = this.lastMessageId + 4L;
      this.lastMessageId = newMessageId;
      return newMessageId;
    }
  }
}
