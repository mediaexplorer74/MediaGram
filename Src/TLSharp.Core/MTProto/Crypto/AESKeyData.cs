// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.MTProto.Crypto.AESKeyData
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

#nullable disable
namespace TLSharp.Core.MTProto.Crypto
{
  public class AESKeyData
  {
    private readonly byte[] key;
    private readonly byte[] iv;

    public AESKeyData(byte[] key, byte[] iv)
    {
      this.key = key;
      this.iv = iv;
    }

    public byte[] Key => this.key;

    public byte[] Iv => this.iv;
  }
}
