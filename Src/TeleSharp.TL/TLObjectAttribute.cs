// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLObjectAttribute
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System;

#nullable disable
namespace TeleSharp.TL
{
  public class TLObjectAttribute : Attribute
  {
    public int Constructor { get; private set; }

    public TLObjectAttribute(int Constructor) => this.Constructor = Constructor;
  }
}
