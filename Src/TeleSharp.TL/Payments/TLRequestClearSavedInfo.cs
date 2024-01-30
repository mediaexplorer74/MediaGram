// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Payments.TLRequestClearSavedInfo
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Payments
{
  [TLObject(-667062079)]
  public class TLRequestClearSavedInfo : TLMethod
  {
    public override int Constructor => -667062079;

    public int Flags { get; set; }

    public bool Credentials { get; set; }

    public bool Info { get; set; }

    public bool Response { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Credentials ? this.Flags | 1 : this.Flags & -2;
      this.Flags = this.Info ? this.Flags | 2 : this.Flags & -3;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Credentials = (this.Flags & 1) != 0;
      this.Info = (this.Flags & 2) != 0;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = BoolUtil.Deserialize(br);
    }
  }
}
