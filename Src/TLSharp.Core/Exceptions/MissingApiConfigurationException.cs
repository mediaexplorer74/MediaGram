// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.Exceptions.MissingApiConfigurationException
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using System;

#nullable disable
namespace TLSharp.Core.Exceptions
{
  public class MissingApiConfigurationException : Exception
  {
    public const string InfoUrl = "https://github.com/sochix/TLSharp#quick-configuration";

    internal MissingApiConfigurationException(string invalidParamName)
      : base(string.Format("Your {0} setting is missing. Adjust the configuration first, see {1}", (object) invalidParamName, (object) "https://github.com/sochix/TLSharp#quick-configuration"))
    {
    }
  }
}
