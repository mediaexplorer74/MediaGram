// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.FileSessionStore
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using System;
using System.IO;

#nullable disable
namespace TLSharp.Core
{
  public class FileSessionStore : ISessionStore
  {
    private readonly DirectoryInfo basePath;

    public FileSessionStore(DirectoryInfo basePath = null)
    {
      this.basePath = basePath == null || basePath.Exists ? basePath : throw new ArgumentException("basePath doesn't exist", nameof (basePath));
    }

    public void Save(Session session)
    {
      string path2 = string.Format("{0}.dat", (object) session.SessionUserId);
      using (FileStream fileStream = new FileStream(this.basePath == null ? path2 : Path.Combine(this.basePath.FullName, path2), FileMode.OpenOrCreate))
      {
        byte[] bytes = session.ToBytes();
        fileStream.Write(bytes, 0, bytes.Length);
      }
    }

    public Session Load(string sessionUserId)
    {
      string path2 = string.Format("{0}.dat", (object) sessionUserId);
      string path = this.basePath == null ? path2 : Path.Combine(this.basePath.FullName, path2);
      if (!File.Exists(path))
        return (Session) null;
      using (FileStream fileStream = new FileStream(path, FileMode.Open))
      {
        byte[] buffer = new byte[2048];
        fileStream.Read(buffer, 0, 2048);
        return Session.FromBytes(buffer, (ISessionStore) this, sessionUserId);
      }
    }
  }
}
