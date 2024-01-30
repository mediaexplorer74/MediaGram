// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.MTProto.Crypto.FactorizedPair
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

#nullable disable
namespace TLSharp.Core.MTProto.Crypto
{
  public class FactorizedPair
  {
    private readonly BigInteger p;
    private readonly BigInteger q;

    public FactorizedPair(BigInteger p, BigInteger q)
    {
      this.p = p;
      this.q = q;
    }

    public FactorizedPair(long p, long q)
    {
      this.p = BigInteger.ValueOf(p);
      this.q = BigInteger.ValueOf(q);
    }

    public BigInteger Min => this.p.Min(this.q);

    public BigInteger Max => this.p.Max(this.q);

    public override string ToString()
    {
      return string.Format("P: {0}, Q: {1}", (object) this.p, (object) this.q);
    }
  }
}
