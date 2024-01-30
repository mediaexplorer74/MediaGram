// Decompiled with JetBrains decompiler
// Type: TeleSharp.TL.TLMethod
// Assembly: TeleSharp.TL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D59BC93E-305A-448E-BA46-6058B4594C3D
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TeleSharp.TL.dll

using System;
using System.IO;

#nullable disable
namespace TeleSharp.TL
{
  public abstract class TLMethod : TLObject
  {
    public abstract void DeserializeResponse(BinaryReader stream);

    public long MessageId { get; set; }

    public int Sequence { get; set; }

    public bool Dirty { get; set; }

    public bool Sended { get; private set; }

    public DateTime SendTime { get; private set; }

    public bool ConfirmReceived { get; set; }

    public virtual bool Confirmed { get; } = true;

    public virtual bool Responded { get; } = false;

    public virtual void OnSendSuccess()
    {
      this.SendTime = DateTime.Now;
      this.Sended = true;
    }

    public virtual void OnConfirm() => this.ConfirmReceived = true;

    public bool NeedResend
    {
      get
      {
        return this.Dirty || this.Confirmed && !this.ConfirmReceived && DateTime.Now - this.SendTime > TimeSpan.FromSeconds(3.0);
      }
    }
  }
}
