using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asense.WeChatAPISecure.Signature.Models;

namespace Asense.WeChatAPISecure.Signature.Encryption
{
    public interface IEncryptService
    {
        /// <summary>
        /// AES256_GCM数据加密
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<AesGcmEncryptResponse> AesGcmEncryption(AesGcmEncryptRequest request);

        /// <summary>
        /// AES256_GCM数据解密
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<T> AesGcmDecrypt<T>(AesGcmDecryptRequest request);
    }
}
