// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.Messages.TLRequestGetAttachedStickers
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL.Messages
{
  [TLObject(-866424884)]
  public class TLRequestGetAttachedStickers : TLMethod
  {
    public override int Constructor => -866424884;

    public TLAbsInputStickeredMedia Media { get; set; }

    public TLVector<TLAbsStickerSetCovered> Response { get; set; }

    public void ComputeFlags()
    {
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Media = (TLAbsInputStickeredMedia) ObjectUtils.DeserializeObject(br);
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      ObjectUtils.SerializeObject((object) this.Media, bw);
    }

    public override void DeserializeResponse(BinaryReader br)
    {
      this.Response = ObjectUtils.DeserializeVector<TLAbsStickerSetCovered>(br);
    }
  }
}
