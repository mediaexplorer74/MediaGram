// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.Auth.Step3_Response
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using TLSharp.Core.MTProto.Crypto;

#nullable disable
namespace TLSharp.Core.Auth
{
  public class Step3_Response
  {
    public AuthKey AuthKey { get; set; }

    public int TimeOffset { get; set; }
  }
}
