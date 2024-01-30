// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLMessageFwdHeader
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-947462709)]
  public class TLMessageFwdHeader : TLObject
  {
    public override int Constructor => -947462709;

    public int Flags { get; set; }

    public int? FromId { get; set; }

    public int Date { get; set; }

    public int? ChannelId { get; set; }

    public int? ChannelPost { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.FromId.HasValue ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.ChannelId.HasValue ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.ChannelPost.HasValue ? this.Flags | 4 : this.Flags & -5;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.FromId = (this.Flags & 1) == 0 ? new int?() : new int?(br.ReadInt32());
      this.Date = br.ReadInt32();
      this.ChannelId = (this.Flags & 2) == 0 ? new int?() : new int?(br.ReadInt32());
      if ((this.Flags & 4) != 0)
        this.ChannelPost = new int?(br.ReadInt32());
      else
        this.ChannelPost = new int?();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      int? nullable;
      if ((this.Flags & 1) != 0)
      {
        BinaryWriter binaryWriter = bw;
        nullable = this.FromId;
        int num = nullable.Value;
        binaryWriter.Write(num);
      }
      bw.Write(this.Date);
      if ((this.Flags & 2) != 0)
      {
        BinaryWriter binaryWriter = bw;
        nullable = this.ChannelId;
        int num = nullable.Value;
        binaryWriter.Write(num);
      }
      if ((this.Flags & 4) == 0)
        return;
      BinaryWriter binaryWriter1 = bw;
      nullable = this.ChannelPost;
      int num1 = nullable.Value;
      binaryWriter1.Write(num1);
    }
  }
}
