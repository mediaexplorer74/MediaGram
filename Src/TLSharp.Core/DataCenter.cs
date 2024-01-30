// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.DataCenter
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

#nullable disable
namespace TLSharp.Core
{
  internal class DataCenter
  {
    internal DataCenter(int? dcId, string address, int port)
    {
      this.DataCenterId = dcId;
      this.Address = address;
      this.Port = port;
    }

    internal DataCenter(string address, int port)
      : this(new int?(), address, port)
    {
    }

    internal int? DataCenterId { get; }

    internal string Address { get; }

    internal int Port { get; }
  }
}
