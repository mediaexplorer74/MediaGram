﻿// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.Network.Exceptions.UserMigrationException
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

#nullable disable
namespace TLSharp.Core.Network.Exceptions
{
  internal class UserMigrationException : DataCenterMigrationException
  {
    internal UserMigrationException(int dc)
      : base(string.Format("User located on a different DC: {0}.", (object) dc), dc)
    {
    }
  }
}
