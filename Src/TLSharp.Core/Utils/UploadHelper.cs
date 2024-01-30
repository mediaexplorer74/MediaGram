// Decompiled with JetBrains decompiler
// Type: TLSharp.Core.Utils.UploadHelper
// Assembly: TLSharp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8F392D-9E6F-4836-8C05-AC47637C2747
// Assembly location: C:\Users\Admin\Desktop\RE\Shagram\TLSharp.Core.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TeleSharp.TL;
using TeleSharp.TL.Upload;

#nullable disable
namespace TLSharp.Core.Utils
{
  public static class UploadHelper
  {
    private static string GetFileHash(byte[] data)
    {
      string fileHash;
      using (MD5 md5 = MD5.Create())
      {
        byte[] hash = md5.ComputeHash(data);
        StringBuilder stringBuilder = new StringBuilder(hash.Length * 2);
        foreach (byte num in hash)
          stringBuilder.Append(num.ToString("x2"));
        fileHash = stringBuilder.ToString();
      }
      return fileHash;
    }

    public static async Task<TLAbsInputFile> UploadFile(
      this TelegramClient client,
      string name,
      StreamReader reader,
      CancellationToken token = default (CancellationToken))
    {
      TLAbsInputFile tlAbsInputFile = await UploadHelper.UploadFile(name, reader, client, reader.BaseStream.Length >= 10485760L, token).ConfigureAwait(false);
      return tlAbsInputFile;
    }

    private static byte[] GetFile(StreamReader reader)
    {
      byte[] buffer = new byte[reader.BaseStream.Length];
      using (reader)
        reader.BaseStream.Read(buffer, 0, (int) reader.BaseStream.Length);
      return buffer;
    }

    private static Queue<byte[]> GetFileParts(byte[] file)
    {
      Queue<byte[]> fileParts = new Queue<byte[]>();
      using (MemoryStream memoryStream = new MemoryStream(file))
      {
        while (memoryStream.Position != memoryStream.Length)
        {
          if (memoryStream.Length - memoryStream.Position > 524288L)
          {
            byte[] buffer = new byte[524288];
            memoryStream.Read(buffer, 0, 524288);
            fileParts.Enqueue(buffer);
          }
          else
          {
            long count = memoryStream.Length - memoryStream.Position;
            byte[] buffer = new byte[count];
            memoryStream.Read(buffer, 0, (int) count);
            fileParts.Enqueue(buffer);
          }
        }
      }
      return fileParts;
    }

    private static async Task<TLAbsInputFile> UploadFile(
      string name,
      StreamReader reader,
      TelegramClient client,
      bool isBigFileUpload,
      CancellationToken token = default (CancellationToken))
    {
      token.ThrowIfCancellationRequested();
      byte[] file = UploadHelper.GetFile(reader);
      Queue<byte[]> fileParts = UploadHelper.GetFileParts(file);
      int partNumber = 0;
      int partsCount = fileParts.Count;
      long file_id = BitConverter.ToInt64(Helpers.GenerateRandomBytes(8), 0);
      while (fileParts.Count != 0)
      {
        byte[] part = fileParts.Dequeue();
        if (isBigFileUpload)
        {
          TelegramClient telegramClient = client;
          TLRequestSaveBigFilePart methodToExecute = new TLRequestSaveBigFilePart();
          methodToExecute.FileId = file_id;
          methodToExecute.FilePart = partNumber;
          methodToExecute.Bytes = part;
          methodToExecute.FileTotalParts = partsCount;
          CancellationToken token1 = token;
          int num = await telegramClient.SendAuthenticatedRequestAsync<bool>((TLMethod) methodToExecute, token1).ConfigureAwait(false) ? 1 : 0;
        }
        else
        {
          TelegramClient telegramClient = client;
          TLRequestSaveFilePart methodToExecute = new TLRequestSaveFilePart();
          methodToExecute.FileId = file_id;
          methodToExecute.FilePart = partNumber;
          methodToExecute.Bytes = part;
          CancellationToken token2 = token;
          int num = await telegramClient.SendAuthenticatedRequestAsync<bool>((TLMethod) methodToExecute, token2).ConfigureAwait(false) ? 1 : 0;
        }
        ++partNumber;
        part = (byte[]) null;
      }
      if (isBigFileUpload)
        return (TLAbsInputFile) new TLInputFileBig()
        {
          Id = file_id,
          Name = name,
          Parts = partsCount
        };
      return (TLAbsInputFile) new TLInputFile()
      {
        Id = file_id,
        Name = name,
        Parts = partsCount,
        Md5Checksum = UploadHelper.GetFileHash(file)
      };
    }
  }
}
