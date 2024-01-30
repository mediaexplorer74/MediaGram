// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.BytesUtil
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  public class BytesUtil
  {
    private static byte[] read(BinaryReader binaryReader)
    {
      byte num1 = binaryReader.ReadByte();
      int count1;
      int num2;
      if (num1 == (byte) 254)
      {
        count1 = (int) binaryReader.ReadByte() | (int) binaryReader.ReadByte() << 8 | (int) binaryReader.ReadByte() << 16;
        num2 = count1 % 4;
      }
      else
      {
        count1 = (int) num1;
        num2 = (count1 + 1) % 4;
      }
      byte[] numArray = binaryReader.ReadBytes(count1);
      if (num2 > 0)
      {
        int count2 = 4 - num2;
        binaryReader.ReadBytes(count2);
      }
      return numArray;
    }

    private static BinaryWriter write(BinaryWriter binaryWriter, byte[] data)
    {
      int num;
      if (data.Length < 254)
      {
        num = (data.Length + 1) % 4;
        if (num != 0)
          num = 4 - num;
        binaryWriter.Write((byte) data.Length);
        binaryWriter.Write(data);
      }
      else
      {
        num = data.Length % 4;
        if (num != 0)
          num = 4 - num;
        binaryWriter.Write((byte) 254);
        binaryWriter.Write((byte) data.Length);
        binaryWriter.Write((byte) (data.Length >> 8));
        binaryWriter.Write((byte) (data.Length >> 16));
        binaryWriter.Write(data);
      }
      for (int index = 0; index < num; ++index)
        binaryWriter.Write((byte) 0);
      return binaryWriter;
    }

    public static byte[] Deserialize(BinaryReader reader) => BytesUtil.read(reader);

    public static void Serialize(byte[] src, BinaryWriter writer) => BytesUtil.write(writer, src);
  }
}
