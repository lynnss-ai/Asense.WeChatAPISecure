using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Asense.WeChatAPISecure.Signature.Utils
{
    public class RsaSignUtil
    {
        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="rsaPrivateKey"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public static string RsaSign(string rsaPrivateKey, string payload)
        {
            string sign = string.Empty;
            string key = ReadPrivateKey(rsaPrivateKey);
            byte[] keyBytes = Convert.FromBase64String(key);
            byte[] payloadBytes = Convert.FromBase64String(payload);
            
            using RSA rsa = RSA.Create();
            rsa.ImportPkcs8PrivateKey(keyBytes, out _);
            byte[] sig = rsa.SignData(payloadBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
            sign = Convert.ToBase64String(sig);
            
            return sign;
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="rsaCertificateKey"></param>
        /// <param name="sign"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public static bool VerifySign(string rsaCertificateKey, string sign, string payload)
        {
            bool isSuccess = false;
            string key = ReadCertificate(rsaCertificateKey);
            byte[] keyBytes = Convert.FromBase64String(key);
            byte[] signBytes = Convert.FromBase64String(sign);
            byte[] payloadBytes = Convert.FromBase64String(payload);

            X509Certificate2 cert = new X509Certificate2(keyBytes);
            RSA? rsa = cert.GetRSAPublicKey();
            if (rsa != null)
            {
                isSuccess = rsa.VerifyData(payloadBytes, signBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
            }

            return isSuccess;
        }
        
        /// <summary>
        /// 读取私钥
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string ReadPrivateKey(string key)
        {
            key = key.Replace("-----BEGIN PRIVATE KEY-----", "")
                .Replace("-----END PRIVATE KEY-----", "")
                .Replace("\r", "")
                .Replace("\n", "").Trim();
            return key;
        }

        /// <summary>
        /// 读取Certificate
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string ReadCertificate(string key)
        {
            key = key.Replace("-----BEGIN CERTIFICATE-----", "")
                .Replace("-----END CERTIFICATE-----", "")
                .Replace("\r", "")
                .Replace("\n", "").Trim();
            return key;
        }
    }
}
