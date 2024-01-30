// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestSetInlineGameScore
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(363700068)]
  public class TLRequestSetInlineGameScore : TLMethod
  {
    public override int Constructor => 363700068;

    public int Flags { get; set; }

    public bool EditMessage { get; set; }

    public bool Force { get; set; }

    public TLInputBotInlineMessageID Id { get; set; }

    public TLAbsInputUser UserId { get; set; }

    public int Score { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.EditMessage ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Force ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.EditMessage = (this.Flags & 1) != 0;
      this.Force = (this.Flags & 2) != 0;
      this.Id = (TLInputBotInlineMessageID) ObjectUtils.DeserializeObject(br);
      this.UserId = (TLAbsInputUser) ObjectUtils.DeserializeObject(br);
      this.Score = br.ReadInt32();
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Id, bw);
      ObjectUtils.SerializeObject((object) this.UserId, bw);
      bw.Write(this.Score);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = BoolUtil.Deserialize(br);
    }
  }
}
