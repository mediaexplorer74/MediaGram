// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.Network.Exceptions.FloodException
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using System;

#nullable disable
namespace TLSharp.Core.Network.Exceptions
{
  public class FloodException : Exception
  {
    public TimeSpan TimeToWait { get; private set; }

    internal FloodException(TimeSpan timeToWait)
      : base(string.Format("Flood prevention. Telegram now requires your program to do requests again only after {0} seconds have passed ({1} property).", (object) timeToWait.TotalSeconds, (object) nameof (TimeToWait)) + " If you think the culprit of this problem may lie in TLSharp's implementation, open a Github issue please.")
    {
      this.TimeToWait = timeToWait;
    }
  }
}
