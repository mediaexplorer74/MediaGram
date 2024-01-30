// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.MTProto.Crypto.Crc32
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using System;
using System.Collections.Generic;
using System.Security.Cryptography;

#nullable disable
namespace TLSharp.Core.MTProto.Crypto
{
  public sealed class Crc32 : HashAlgorithm
  {
    public const uint DefaultPolynomial = 3988292384;
    public const uint DefaultSeed = 4294967295;
    private static uint[] defaultTable;
    private readonly uint seed;
    private readonly uint[] table;
    private uint hash;

    public Crc32()
      : this(3988292384U, uint.MaxValue)
    {
    }

    public Crc32(uint polynomial, uint seed)
    {
      if (!BitConverter.IsLittleEndian)
        throw new PlatformNotSupportedException("Not supported on Big Endian processors");
      this.table = Crc32.InitializeTable(polynomial);
      this.seed = this.hash = seed;
    }

    public override void Initialize() => this.hash = this.seed;

    protected override void HashCore(byte[] array, int ibStart, int cbSize)
    {
      this.hash = Crc32.CalculateHash(this.table, this.hash, (IList<byte>) array, ibStart, cbSize);
    }

    protected override byte[] HashFinal()
    {
      byte[] bigEndianBytes = Crc32.UInt32ToBigEndianBytes(~this.hash);
      this.HashValue = bigEndianBytes;
      return bigEndianBytes;
    }

    public override int HashSize => 32;

    public static uint Compute(byte[] buffer) => Crc32.Compute(uint.MaxValue, buffer);

    public static uint Compute(uint seed, byte[] buffer)
    {
      return Crc32.Compute(3988292384U, seed, buffer);
    }

    public static uint Compute(uint polynomial, uint seed, byte[] buffer)
    {
      return ~Crc32.CalculateHash(Crc32.InitializeTable(polynomial), seed, (IList<byte>) buffer, 0, buffer.Length);
    }

    private static uint[] InitializeTable(uint polynomial)
    {
      if (polynomial == 3988292384U && Crc32.defaultTable != null)
        return Crc32.defaultTable;
      uint[] numArray = new uint[256];
      for (int index1 = 0; index1 < 256; ++index1)
      {
        uint num = (uint) index1;
        for (int index2 = 0; index2 < 8; ++index2)
        {
          if (((int) num & 1) == 1)
            num = num >> 1 ^ polynomial;
          else
            num >>= 1;
        }
        numArray[index1] = num;
      }
      if (polynomial == 3988292384U)
        Crc32.defaultTable = numArray;
      return numArray;
    }

    private static uint CalculateHash(
      uint[] table,
      uint seed,
      IList<byte> buffer,
      int start,
      int size)
    {
      uint hash = seed;
      for (int index = start; index < start + size; ++index)
        hash = hash >> 8 ^ table[(int) buffer[index] ^ (int) hash & (int) byte.MaxValue];
      return hash;
    }

    private static byte[] UInt32ToBigEndianBytes(uint uint32)
    {
      byte[] bytes = BitConverter.GetBytes(uint32);
      if (BitConverter.IsLittleEndian)
        Array.Reverse((Array) bytes);
      return bytes;
    }
  }
}
