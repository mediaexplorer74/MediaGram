// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.DoubleUtil
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  public class DoubleUtil
  {
    public static double Deserialize(BinaryReader reader) => reader.ReadDouble();

    public static void Serialize(double src, BinaryWriter writer) => writer.Write(src);
  }
}
