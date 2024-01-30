// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.Network.Exceptions.DataCenterMigrationException
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using System;

#nullable disable
namespace TLSharp.Core.Network.Exceptions
{
  internal abstract class DataCenterMigrationException : Exception
  {
    private const string REPORT_MESSAGE = " See: https://github.com/sochix/TLSharp#i-get-a-xxxmigrationexception-or-a-migrate_x-error";

    internal int DC { get; private set; }

    protected DataCenterMigrationException(string msg, int dc)
      : base(msg + " See: https://github.com/sochix/TLSharp#i-get-a-xxxmigrationexception-or-a-migrate_x-error")
    {
      this.DC = dc;
    }
  }
}
