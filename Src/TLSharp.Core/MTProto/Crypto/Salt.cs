// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.MTProto.Crypto.Salt
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using System;

#nullable disable
namespace TLSharp.Core.MTProto.Crypto
{
  public class Salt : IComparable<Salt>
  {
    private int validSince;
    private int validUntil;
    private ulong salt;

    public Salt(int validSince, int validUntil, ulong salt)
    {
      this.validSince = validSince;
      this.validUntil = validUntil;
      this.salt = salt;
    }

    public int ValidSince => this.validSince;

    public int ValidUntil => this.validUntil;

    public ulong Value => this.salt;

    public int CompareTo(Salt other) => this.validUntil.CompareTo(other.validSince);
  }
}
