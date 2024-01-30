// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputPaymentCredentials
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(873977640)]
  public class TLInputPaymentCredentials : TLAbsInputPaymentCredentials
  {
    public override int Constructor => 873977640;

    public int Flags { get; set; }

    public bool Save { get; set; }

    public TLDataJSON Data { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.Save ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Save = (this.Flags & 1) != 0;
      this.Data = (TLDataJSON) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Data, bw);
    }
  }
}
