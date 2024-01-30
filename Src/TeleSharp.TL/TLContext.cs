// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLContext
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#nullable disable
namespace TeleSharp.TL
{
  public static class TLContext
  {
    private static Dictionary<int, Type> Types = new Dictionary<int, Type>();

    static TLContext()
    {
      TLContext.Types = ((IEnumerable<Type>) Assembly.GetExecutingAssembly().GetTypes()).Where<Type>((Func<Type, bool>) (t => t.IsClass && t.Namespace.StartsWith("TeleSharp.TL"))).Where<Type>((Func<Type, bool>) (t => t.IsSubclassOf(typeof (TLObject)))).Where<Type>((Func<Type, bool>) (t => t.GetCustomAttribute(typeof (TLObjectAttribute)) != null)).ToDictionary<Type, int, Type>((Func<Type, int>) (x => ((TLObjectAttribute) x.GetCustomAttribute(typeof (TLObjectAttribute))).Constructor), (Func<Type, Type>) (x => x));
      TLContext.Types.Add(481674261, typeof (TLVector<>));
    }

    public static Type getType(int Constructor) => TLContext.Types[Constructor];
  }
}
