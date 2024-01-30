// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.MTProto.Crypto.Pack
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

#nullable disable
namespace TLSharp.Core.MTProto.Crypto
{
  internal sealed class Pack
  {
    private Pack()
    {
    }

    internal static void UInt32_To_BE(uint n, byte[] bs)
    {
      bs[0] = (byte) (n >> 24);
      bs[1] = (byte) (n >> 16);
      bs[2] = (byte) (n >> 8);
      bs[3] = (byte) n;
    }

    internal static void UInt32_To_BE(uint n, byte[] bs, int off)
    {
      bs[off] = (byte) (n >> 24);
      bs[++off] = (byte) (n >> 16);
      bs[++off] = (byte) (n >> 8);
      bs[++off] = (byte) n;
    }

    internal static uint BE_To_UInt32(byte[] bs)
    {
      return (uint) bs[0] << 24 | (uint) bs[1] << 16 | (uint) bs[2] << 8 | (uint) bs[3];
    }

    internal static uint BE_To_UInt32(byte[] bs, int off)
    {
      return (uint) bs[off] << 24 | (uint) bs[++off] << 16 | (uint) bs[++off] << 8 | (uint) bs[++off];
    }

    internal static ulong BE_To_UInt64(byte[] bs)
    {
      return (ulong) Pack.BE_To_UInt32(bs) << 32 | (ulong) Pack.BE_To_UInt32(bs, 4);
    }

    internal static ulong BE_To_UInt64(byte[] bs, int off)
    {
      return (ulong) Pack.BE_To_UInt32(bs, off) << 32 | (ulong) Pack.BE_To_UInt32(bs, off + 4);
    }

    internal static void UInt64_To_BE(ulong n, byte[] bs)
    {
      Pack.UInt32_To_BE((uint) (n >> 32), bs);
      Pack.UInt32_To_BE((uint) n, bs, 4);
    }

    internal static void UInt64_To_BE(ulong n, byte[] bs, int off)
    {
      Pack.UInt32_To_BE((uint) (n >> 32), bs, off);
      Pack.UInt32_To_BE((uint) n, bs, off + 4);
    }

    internal static void UInt32_To_LE(uint n, byte[] bs)
    {
      bs[0] = (byte) n;
      bs[1] = (byte) (n >> 8);
      bs[2] = (byte) (n >> 16);
      bs[3] = (byte) (n >> 24);
    }

    internal static void UInt32_To_LE(uint n, byte[] bs, int off)
    {
      bs[off] = (byte) n;
      bs[++off] = (byte) (n >> 8);
      bs[++off] = (byte) (n >> 16);
      bs[++off] = (byte) (n >> 24);
    }

    internal static uint LE_To_UInt32(byte[] bs)
    {
      return (uint) bs[0] | (uint) bs[1] << 8 | (uint) bs[2] << 16 | (uint) bs[3] << 24;
    }

    internal static uint LE_To_UInt32(byte[] bs, int off)
    {
      return (uint) bs[off] | (uint) bs[++off] << 8 | (uint) bs[++off] << 16 | (uint) bs[++off] << 24;
    }

    internal static ulong LE_To_UInt64(byte[] bs)
    {
      uint uint32 = Pack.LE_To_UInt32(bs);
      return (ulong) Pack.LE_To_UInt32(bs, 4) << 32 | (ulong) uint32;
    }

    internal static ulong LE_To_UInt64(byte[] bs, int off)
    {
      uint uint32 = Pack.LE_To_UInt32(bs, off);
      return (ulong) Pack.LE_To_UInt32(bs, off + 4) << 32 | (ulong) uint32;
    }

    internal static void UInt64_To_LE(ulong n, byte[] bs)
    {
      Pack.UInt32_To_LE((uint) n, bs);
      Pack.UInt32_To_LE((uint) (n >> 32), bs, 4);
    }

    internal static void UInt64_To_LE(ulong n, byte[] bs, int off)
    {
      Pack.UInt32_To_LE((uint) n, bs, off);
      Pack.UInt32_To_LE((uint) (n >> 32), bs, off + 4);
    }
  }
}
