// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.MTProto.Crypto.SaltCollection
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using System.Collections.Generic;

#nullable disable
namespace TLSharp.Core.MTProto.Crypto
{
  public class SaltCollection
  {
    private SortedSet<Salt> salts;

    public void Add(Salt salt) => this.salts.Add(salt);

    public int Count => this.salts.Count;
  }
}
