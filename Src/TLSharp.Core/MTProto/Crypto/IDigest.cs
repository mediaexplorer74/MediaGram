// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.MTProto.Crypto.IDigest
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

#nullable disable
namespace TLSharp.Core.MTProto.Crypto
{
  public interface IDigest
  {
    string AlgorithmName { get; }

    int GetDigestSize();

    int GetByteLength();

    void Update(byte input);

    void BlockUpdate(byte[] input, int inOff, int length);

    int DoFinal(byte[] output, int outOff);

    void Reset();
  }
}
