// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Contacts.TLRequestGetTopPeers
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Contacts
{
  [TLObject(-728224331)]
  public class TLRequestGetTopPeers : TLMethod
  {
    public override int Constructor => -728224331;

    public int Flags { get; set; }

    public bool Correspondents { get; set; }

    public bool BotsPm { get; set; }

    public bool BotsInline { get; set; }

    public bool PhoneCalls { get; set; }

    public bool Groups { get; set; }

    public bool Channels { get; set; }

    public int Offset { get; set; }

    public int Limit { get; set; }

    public int Hash { get; set; }

    public TLAbsTopPeers Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Correspondents ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.BotsPm ? this.Flags | 2 : this.Flags & -3;
      this.Flags = this.BotsInline ? this.Flags | 4 : this.Flags & -5;
      this.Flags = this.PhoneCalls ? this.Flags | 8 : this.Flags & -9;
      this.Flags = this.Groups ? this.Flags | 1024 : this.Flags & -1025;
      this.Flags = this.Channels ? this.Flags | 32768 : this.Flags & -32769;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Correspondents = (this.Flags & 1) != 0;
      this.BotsPm = (this.Flags & 2) != 0;
      this.BotsInline = (this.Flags & 4) != 0;
      this.PhoneCalls = (this.Flags & 8) != 0;
      this.Groups = (this.Flags & 1024) != 0;
      this.Channels = (this.Flags & 32768) != 0;
      this.Offset = br.ReadInt32();
      this.Limit = br.ReadInt32();
      this.Hash = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      bw.Write(this.Offset);
      bw.Write(this.Limit);
      bw.Write(this.Hash);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsTopPeers) ObjectUtils.DeserializeObject(br);
    }
  }
}
