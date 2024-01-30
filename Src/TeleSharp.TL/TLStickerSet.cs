// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLStickerSet
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-852477119)]
  public class TLStickerSet : TLObject
  {
    public override int Constructor => -852477119;

    public int Flags { get; set; }

    public bool Installed { get; set; }

    public bool Archived { get; set; }

    public bool Official { get; set; }

    public bool Masks { get; set; }

    public long Id { get; set; }

    public long AccessHash { get; set; }

    public string Title { get; set; }

    public string ShortName { get; set; }

    public int Count { get; set; }

    public int Hash { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Installed ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Archived ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.Official ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.Masks ? this.Flags | 8 : this.Flags & -9;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Installed = (this.Flags & 1) != 0;
      this.Archived = (this.Flags & 2) != 0;
      this.Official = (this.Flags & 4) != 0;
      this.Masks = (this.Flags & 8) != 0;
      this.Id = br.ReadInt64();
      this.AccessHash = br.ReadInt64();
      this.Title = StringUtil.Deserialize(br);
      this.ShortName = StringUtil.Deserialize(br);
      this.Count = br.ReadInt32();
      this.Hash = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Id);
      bw.Write(this.AccessHash);
      StringUtil.Serialize(this.Title, bw);
      StringUtil.Serialize(this.ShortName, bw);
      bw.Write(this.Count);
      bw.Write(this.Hash);
    }
  }
}
