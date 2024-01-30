// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.MTProto.Crypto.GetFutureSaltsResponse
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

#nullable disable
namespace TLSharp.Core.MTProto.Crypto
{
  public class GetFutureSaltsResponse
  {
    private ulong requestId;
    private int now;
    private SaltCollection salts;

    public GetFutureSaltsResponse(ulong requestId, int now)
    {
      this.requestId = requestId;
      this.now = now;
    }

    public void AddSalt(Salt salt) => this.salts.Add(salt);

    public ulong RequestId => this.requestId;

    public int Now => this.now;

    public SaltCollection Salts => this.salts;
  }
}
