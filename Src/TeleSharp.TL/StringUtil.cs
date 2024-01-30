// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.StringUtil
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;
using System.Text;

#nullable disable
namespace TeleSharp.TL
{
  public class StringUtil
  {
    public static string Deserialize(BinaryReader reader)
    {
      byte[] bytes = BytesUtil.Deserialize(reader);
      return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
    }

    public static void Serialize(string src, BinaryWriter writer)
    {
      BytesUtil.Serialize(Encoding.UTF8.GetBytes(src), writer);
    }
  }
}
