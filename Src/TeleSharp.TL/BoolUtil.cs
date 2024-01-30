// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.BoolUtil
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  public class BoolUtil
  {
    public static bool Deserialize(BinaryReader reader)
    {
      int num1 = -1132882121;
      int num2 = -1720552011;
      int num3 = reader.ReadInt32();
      if (num3 == num1)
        return false;
      if (num3 == num2)
        return true;
      throw new InvalidDataException(string.Format("Invalid Boolean Data : {0}", (object) num3.ToString()));
    }

    public static void Serialize(bool src, BinaryWriter writer)
    {
      int num1 = -1132882121;
      int num2 = -1720552011;
      writer.Write(src ? num2 : num1);
    }
  }
}
