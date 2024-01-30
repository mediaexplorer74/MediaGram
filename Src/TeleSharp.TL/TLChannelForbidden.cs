// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLChannelForbidden
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-2059962289)]
  public class TLChannelForbidden : TLAbsChat
  {
    public override int Constructor => -2059962289;

    public int Flags { get; set; }

    public bool Broadcast { get; set; }

    public bool Megagroup { get; set; }

    public int Id { get; set; }

    public long AccessHash { get; set; }

    public string Title { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Broadcast ? this.Flags | 32 : this.Flags & -33;
      this.Flags = this.Megagroup ? this.Flags | 256 : this.Flags & -257;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Broadcast = (this.Flags & 32) != 0;
      this.Megagroup = (this.Flags & 256) != 0;
      this.Id = br.ReadInt32();
      this.AccessHash = br.ReadInt64();
      this.Title = StringUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Id);
      bw.Write(this.AccessHash);
      StringUtil.Serialize(this.Title, bw);
    }
  }
}
