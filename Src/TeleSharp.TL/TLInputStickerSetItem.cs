// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLInputStickerSetItem
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  [TLObject(-6249322)]
  public class TLInputStickerSetItem : TLObject
  {
    public override int Constructor => -6249322;

    public int Flags { get; set; }

    public TLAbsInputDocument Document { get; set; }

    public string Emoji { get; set; }

    public TLMaskCoords MaskCoords { get; set; }

    public void ComputeFlags()
    {
      this.Flags = 0;
      this.Flags = this.MaskCoords != null ? this.Flags | 1 : this.Flags & -2;
    }

    public override void DeserializeBody(BinaryReader br)
    {
      this.Flags = br.ReadInt32();
      this.Document = (TLAbsInputDocument) ObjectUtils.DeserializeObject(br);
      this.Emoji = StringUtil.Deserialize(br);
      if ((this.Flags & 1) != 0)
        this.MaskCoords = (TLMaskCoords) ObjectUtils.DeserializeObject(br);
      else
        this.MaskCoords = (TLMaskCoords) null;
    }

    public override void SerializeBody(BinaryWriter bw)
    {
      bw.Write(this.Constructor);
      this.ComputeFlags();
      bw.Write(this.Flags);
      ObjectUtils.SerializeObject((object) this.Document, bw);
      StringUtil.Serialize(this.Emoji, bw);
      if ((this.Flags & 1) == 0)
        return;
      ObjectUtils.SerializeObject((object) this.MaskCoords, bw);
    }
  }
}
