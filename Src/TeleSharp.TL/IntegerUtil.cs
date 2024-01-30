// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.IntegerUtil
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  public class IntegerUtil
  {
    public static int Deserialize(BinaryReader reader) => reader.ReadInt32();

    public static void Serialize(int src, BinaryWriter writer) => writer.Write(src);
  }
}
