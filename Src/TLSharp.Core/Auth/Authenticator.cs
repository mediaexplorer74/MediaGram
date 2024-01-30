// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.Auth.Authenticator
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using TLSharp.Core.Network;

#nullable disable
namespace TLSharp.Core.Auth
{
  public static class Authenticator
  {
    public static async Task<Step3_Response> DoAuthentication(
      TcpTransport transport,
      CancellationToken token = default (CancellationToken))
    {
      token.ThrowIfCancellationRequested();
      MtProtoPlainSender sender = new MtProtoPlainSender(transport);
      Step1_PQRequest step1 = new Step1_PQRequest();
      ConfiguredTaskAwaitable configuredTaskAwaitable = sender.Send(step1.ToBytes(), token).ConfigureAwait(false);
      await configuredTaskAwaitable;
      Step1_PQRequest step1PqRequest = step1;
      byte[] bytes = await sender.Receive(token).ConfigureAwait(false);
      Step1_Response step1Response = step1PqRequest.FromBytes(bytes);
      step1PqRequest = (Step1_PQRequest) null;
      bytes = (byte[]) null;
      Step2_DHExchange step2 = new Step2_DHExchange();
      configuredTaskAwaitable = sender.Send(step2.ToBytes(step1Response.Nonce, step1Response.ServerNonce, step1Response.Fingerprints, step1Response.Pq), token).ConfigureAwait(false);
      await configuredTaskAwaitable;
      Step2_DHExchange step2DhExchange = step2;
      byte[] response1 = await sender.Receive(token).ConfigureAwait(false);
      Step2_Response step2Response = step2DhExchange.FromBytes(response1);
      step2DhExchange = (Step2_DHExchange) null;
      response1 = (byte[]) null;
      Step3_CompleteDHExchange step3 = new Step3_CompleteDHExchange();
      configuredTaskAwaitable = sender.Send(step3.ToBytes(step2Response.Nonce, step2Response.ServerNonce, step2Response.NewNonce, step2Response.EncryptedAnswer), token).ConfigureAwait(false);
      await configuredTaskAwaitable;
      Step3_CompleteDHExchange completeDhExchange = step3;
      byte[] response2 = await sender.Receive(token).ConfigureAwait(false);
      Step3_Response step3Response = completeDhExchange.FromBytes(response2);
      completeDhExchange = (Step3_CompleteDHExchange) null;
      response2 = (byte[]) null;
      return step3Response;
    }
  }
}
