// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.Network.TcpTransport
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using TLSharp.Core.MTProto.Crypto;

#nullable disable
namespace TLSharp.Core.Network
{
  public class TcpTransport : IDisposable
  {
    private readonly TcpClient tcpClient;
    private readonly NetworkStream stream;
    private int sendCounter = 0;

    public TcpTransport(string address, int port, TcpClientConnectionHandler handler = null)
    {
      if (handler == null)
      {
        IPAddress address1 = IPAddress.Parse(address);
        IPEndPoint remoteEP = new IPEndPoint(address1, port);
        this.tcpClient = new TcpClient(address1.AddressFamily);
        try
        {
          this.tcpClient.Connect(remoteEP);
        }
        catch (Exception ex)
        {
          throw new Exception(string.Format("Problem when trying to connect to {0}; either there's no internet connection or the IP address version is not compatible (if the latter, consider using DataCenterIPVersion enum)", (object) remoteEP), ex);
        }
      }
      else
        this.tcpClient = handler(address, port);
      if (!this.tcpClient.Connected)
        return;
      this.stream = this.tcpClient.GetStream();
    }

    public async Task Send(byte[] packet, CancellationToken token = default (CancellationToken))
    {
      if (!this.tcpClient.Connected)
        throw new InvalidOperationException("Client not connected to server.");
      TcpMessage tcpMessage = new TcpMessage(this.sendCounter, packet);
      await this.stream.WriteAsync(tcpMessage.Encode(), 0, tcpMessage.Encode().Length, token).ConfigureAwait(false);
      ++this.sendCounter;
    }

    public async Task<TcpMessage> Receive(CancellationToken token = default (CancellationToken))
    {
      byte[] packetLengthBytes = new byte[4];
      ConfiguredTaskAwaitable<int> configuredTaskAwaitable = this.stream.ReadAsync(packetLengthBytes, 0, 4, token).ConfigureAwait(false);
      int num1 = await configuredTaskAwaitable;
      if (num1 != 4)
        throw new InvalidOperationException("Couldn't read the packet length");
      int packetLength = BitConverter.ToInt32(packetLengthBytes, 0);
      byte[] seqBytes = new byte[4];
      configuredTaskAwaitable = this.stream.ReadAsync(seqBytes, 0, 4, token).ConfigureAwait(false);
      int num2 = await configuredTaskAwaitable;
      if (num2 != 4)
        throw new InvalidOperationException("Couldn't read the sequence");
      int seq = BitConverter.ToInt32(seqBytes, 0);
      int readBytes = 0;
      byte[] body = new byte[packetLength - 12];
      int neededToRead = packetLength - 12;
      do
      {
        byte[] bodyByte = new byte[packetLength - 12];
        configuredTaskAwaitable = this.stream.ReadAsync(bodyByte, 0, neededToRead, token).ConfigureAwait(false);
        int availableBytes = await configuredTaskAwaitable;
        neededToRead -= availableBytes;
        Buffer.BlockCopy((Array) bodyByte, 0, (Array) body, readBytes, availableBytes);
        readBytes += availableBytes;
        bodyByte = (byte[]) null;
      }
      while (readBytes != packetLength - 12);
      byte[] crcBytes = new byte[4];
      configuredTaskAwaitable = this.stream.ReadAsync(crcBytes, 0, 4, token).ConfigureAwait(false);
      int num3 = await configuredTaskAwaitable;
      if (num3 != 4)
        throw new InvalidOperationException("Couldn't read the crc");
      byte[] rv = new byte[packetLengthBytes.Length + seqBytes.Length + body.Length];
      Buffer.BlockCopy((Array) packetLengthBytes, 0, (Array) rv, 0, packetLengthBytes.Length);
      Buffer.BlockCopy((Array) seqBytes, 0, (Array) rv, packetLengthBytes.Length, seqBytes.Length);
      Buffer.BlockCopy((Array) body, 0, (Array) rv, packetLengthBytes.Length + seqBytes.Length, body.Length);
      Crc32 crc32 = new Crc32();
      IEnumerable<byte> computedChecksum = ((IEnumerable<byte>) crc32.ComputeHash(rv)).Reverse<byte>();
      if (!((IEnumerable<byte>) crcBytes).SequenceEqual<byte>(computedChecksum))
        throw new InvalidOperationException("invalid checksum! skip");
      return new TcpMessage(seq, body);
    }

    public bool IsConnected => this.tcpClient.Connected;

    public void Dispose()
    {
      if (!this.tcpClient.Connected)
        return;
      this.stream.Close();
      this.tcpClient.Close();
    }
  }
}
