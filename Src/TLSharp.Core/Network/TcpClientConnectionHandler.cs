// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.Network.TcpClientConnectionHandler
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using System.Net.Sockets;

#nullable disable
namespace TLSharp.Core.Network
{
  public delegate TcpClient TcpClientConnectionHandler(string address, int port);
}
