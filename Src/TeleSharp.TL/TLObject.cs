// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLObject
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  public abstract class TLObject
  {
    public abstract int Constructor { get; }

    public abstract void SerializeBody(BinaryWriter bw);

    public abstract void DeserializeBody(BinaryReader br);

    public byte[] Serialize()
    {
      using (MemoryStream output = new MemoryStream())
      {
        using (BinaryWriter writer = new BinaryWriter((Stream) output))
        {
          this.Serialize(writer);
          writer.Close();
          output.Close();
          return output.ToArray();
        }
      }
    }

    public void Serialize(BinaryWriter writer)
    {
      writer.Write(this.Constructor);
      this.SerializeBody(writer);
    }

    public void Deserialize(BinaryReader reader)
    {
      if (reader.ReadInt32() != this.Constructor)
        throw new InvalidDataException("Constructor Invalid");
      this.DeserializeBody(reader);
    }
  }
}
