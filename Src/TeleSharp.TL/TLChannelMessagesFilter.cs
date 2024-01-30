// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLChannelMessagesFilter
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-847783593)]
  public class TLChannelMessagesFilter : TLAbsChannelMessagesFilter
  {
    public override int Constructor => -847783593;

    public int Flags { get; set; }

    public bool ExcludeNewMessages { get; set; }

    public TLVector<TLMessageRange> Ranges { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.ExcludeNewMessages ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.ExcludeNewMessages = (this.Flags & 2) != 0;
      this.Ranges = ObjectUtils.DeserializeVector<TLMessageRange>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Ranges, bw);
    }
  }
}
