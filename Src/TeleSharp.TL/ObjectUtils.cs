// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.ObjectUtils
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System;
using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  public class ObjectUtils
  {
    public static object DeserializeObject(BinaryReader reader)
    {
      int Constructor = reader.ReadInt32();
      Type type;
      object instance;
      try
      {
        type = TLContext.getType(Constructor);
        instance = Activator.CreateInstance(type);
      }
      catch (Exception ex)
      {
        throw new InvalidDataException("Constructor Invalid Or Context.Init Not Called !", ex);
      }
      if (type.IsSubclassOf(typeof (TLMethod)))
      {
        ((TLMethod) instance).DeserializeResponse(reader);
        return instance;
      }
      if (!type.IsSubclassOf(typeof (TLObject)))
        throw new NotImplementedException("Weird Type : " + type.Namespace + " | " + type.Name);
      ((TLObject) instance).DeserializeBody(reader);
      return instance;
    }

    public static void SerializeObject(object obj, BinaryWriter writer)
    {
      ((TLObject) obj).SerializeBody(writer);
    }

    public static TLVector<T> DeserializeVector<T>(BinaryReader reader)
    {
      if (reader.ReadInt32() != 481674261)
        throw new InvalidDataException("Bad Constructor");
      TLVector<T> tlVector = new TLVector<T>();
      tlVector.DeserializeBody(reader);
      return tlVector;
    }
  }
}
