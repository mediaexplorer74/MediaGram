// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestInstallStickerSet
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-946871200)]
  public class TLRequestInstallStickerSet : TLMethod
  {
    public override int Constructor => -946871200;

    public TLAbsInputStickerSet Stickerset { get; set; }

    public bool Archived { get; set; }

    public TLAbsStickerSetInstallResult Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Stickerset = (TLAbsInputStickerSet) ObjectUtils.DeserializeObject(br);
      this.Archived = BoolUtil.Deserialize(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Stickerset, bw);
      BoolUtil.Serialize(this.Archived, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = (TLAbsStickerSetInstallResult) ObjectUtils.DeserializeObject(br);
    }
  }
}
