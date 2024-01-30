﻿// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.MTProto.Crypto.RSA
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using System.Collections.Generic;

#nullable disable
namespace TLSharp.Core.MTProto.Crypto
{
  public class RSA
  {
    private static readonly Dictionary<string, RSAServerKey> serverKeys = new Dictionary<string, RSAServerKey>()
    {
      {
        "216be86c022bb4c3",
        new RSAServerKey("216be86c022bb4c3", new BigInteger("00C150023E2F70DB7985DED064759CFECF0AF328E69A41DAF4D6F01B538135A6F91F8F8B2A0EC9BA9720CE352EFCF6C5680FFC424BD634864902DE0B4BD6D49F4E580230E3AE97D95C8B19442B3C0A10D8F5633FECEDD6926A7F6DAB0DDB7D457F9EA81B8465FCD6FFFEED114011DF91C059CAEDAF97625F6C96ECC74725556934EF781D866B34F011FCE4D835A090196E9A5F0E4449AF7EB697DDB9076494CA5F81104A305B6DD27665722C46B60E5DF680FB16B210607EF217652E60236C255F6A28315F4083A96791D7214BF64C1DF4FD0DB1944FB26A2A57031B32EEE64AD15A8BA68885CDE74A5BFC920F6ABF59BA5C75506373E7130F9042DA922179251F", 16), new BigInteger("010001", 16))
      }
    };

    public static byte[] Encrypt(string fingerprint, byte[] data, int offset, int length)
    {
      string lower = fingerprint.ToLower();
      return !RSA.serverKeys.ContainsKey(lower) ? (byte[]) null : RSA.serverKeys[lower].Encrypt(data, offset, length);
    }
  }
}
