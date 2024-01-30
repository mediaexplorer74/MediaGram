// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Contacts.TLRequestImportCard
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Contacts
{
  [TLObject(1340184318)]
  public class TLRequestImportCard : TLMethod
  {
    public override int Constructor => 1340184318;

    public TLVector<int> ExportCard { get; set; }

    public TLAbsUser Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.ExportCard = ObjectUtils.DeserializeVector<int>(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.ExportCard, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsUser) ObjectUtils.DeserializeObject(br);
    }
  }
}
