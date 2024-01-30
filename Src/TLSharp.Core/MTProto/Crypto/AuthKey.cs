// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.MTProto.Crypto.AuthKey
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using System;
using System.IO;
using System.Security.Cryptography;

#nullable disable
namespace TLSharp.Core.MTProto.Crypto
{
  public class AuthKey
  {
    private byte[] key;
    private ulong keyId;
    private ulong auxHash;

    public AuthKey(BigInteger gab)
    {
      this.key = gab.ToByteArrayUnsigned();
      using (SHA1 shA1 = (SHA1) new SHA1Managed())
      {
        using (MemoryStream input = new MemoryStream(shA1.ComputeHash(this.key), false))
        {
          using (BinaryReader binaryReader = new BinaryReader((Stream) input))
          {
            this.auxHash = binaryReader.ReadUInt64();
            binaryReader.ReadBytes(4);
            this.keyId = binaryReader.ReadUInt64();
          }
        }
      }
    }

    public AuthKey(byte[] data)
    {
      this.key = data;
      using (SHA1 shA1 = (SHA1) new SHA1Managed())
      {
        using (MemoryStream input = new MemoryStream(shA1.ComputeHash(this.key), false))
        {
          using (BinaryReader binaryReader = new BinaryReader((Stream) input))
          {
            this.auxHash = binaryReader.ReadUInt64();
            binaryReader.ReadBytes(4);
            this.keyId = binaryReader.ReadUInt64();
          }
        }
      }
    }

    public byte[] CalcNewNonceHash(byte[] newNonce, int number)
    {
      using (MemoryStream output = new MemoryStream(100))
      {
        using (BinaryWriter binaryWriter = new BinaryWriter((Stream) output))
        {
          binaryWriter.Write(newNonce);
          binaryWriter.Write((byte) number);
          binaryWriter.Write(this.auxHash);
          using (SHA1 shA1 = (SHA1) new SHA1Managed())
          {
            byte[] hash = shA1.ComputeHash(output.GetBuffer(), 0, (int) output.Position);
            byte[] destinationArray = new byte[16];
            Array.Copy((Array) hash, 4, (Array) destinationArray, 0, 16);
            return destinationArray;
          }
        }
      }
    }

    public byte[] Data => this.key;

    public ulong Id => this.keyId;

    public override string ToString()
    {
      return string.Format("(Key: {0}, KeyId: {1}, AuxHash: {2})", (object) this.key, (object) this.keyId, (object) this.auxHash);
    }
  }
}
