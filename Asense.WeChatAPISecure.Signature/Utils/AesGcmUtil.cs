using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Asense.WeChatAPISecure.Signature.Models;
using Newtonsoft.Json;

namespace Asense.WeChatAPISecure.Signature.Utils
{
    public class AesGcmUtil
    {
        /// <summary>
        /// AesGcm数据加密
        /// </summary>
        /// <param name="aad"></param>
        /// <param name="aesKey"></param>
        /// <param name="iv"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static AesGcmEncryptResponse AesGcmEncryptData(byte[] aad, byte[] aesKey, byte[] iv, byte[] data)
        {
            try
            {
                using AesGcm aesGcm = new AesGcm(aesKey);
                byte[] cipherText = new byte[data.Length];
                byte[] authTag = new byte[16];
                aesGcm.Encrypt(iv, data, cipherText, authTag, aad);

                var result = new AesGcmEncryptResponse()
                {
                    Iv = Convert.ToBase64String(iv).Replace("=", ""),
                    Data = Convert.ToBase64String(cipherText),
                    AuthTag = Convert.ToBase64String(authTag)
                };

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception($"AESGCM加密数据失败:{ex.Message}");
            }
        }

        /// <summary>
        /// AesGcm数据解密
        /// </summary>
        /// <param name="aad"></param>
        /// <param name="aesKey"></param>
        /// <param name="iv"></param>
        /// <param name="data"></param>
        /// <param name="authTag"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string AesGcmDecryptData(byte[] aad, byte[] aesKey, byte[] iv, byte[] data, byte[] authTag)
        {
            try
            {
                using AesGcm aesGcm = new AesGcm(aesKey);
                byte[] decryptText = new byte[data.Length];

                aesGcm.Decrypt(iv, data, authTag, decryptText, aad);
                return Encoding.UTF8.GetString(decryptText);
            }
            catch (Exception ex)
            {
                throw new Exception($"AESGCM解密数据失败:{ex.Message}");
            }
        }
    }
}
