// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.MTProto.Serializers
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using System.IO;
using System.Text;

#nullable disable
namespace TLSharp.Core.MTProto
{
  public class Serializers
  {
    public static class Bytes
    {
      public static byte[] Read(BinaryReader binaryReader)
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

      public static BinaryWriter Write(BinaryWriter binaryWriter, byte[] data)
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
    }

    public static class String
    {
      public static string Read(BinaryReader reader)
      {
        byte[] bytes = Serializers.Bytes.Read(reader);
        return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
      }

      public static BinaryWriter Write(BinaryWriter writer, string str)
      {
        return Serializers.Bytes.Write(writer, Encoding.UTF8.GetBytes(str));
      }
    }
  }
}
