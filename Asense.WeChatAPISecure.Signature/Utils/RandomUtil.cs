using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Asense.WeChatAPISecure.Signature.Utils
{
    public class RandomUtil
    {
        /// <summary>
        /// 生成指定长度的随机字节
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static byte[] GenerateRandomBytes(int length)
        {
            byte[] randomBytes = new byte[length];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }
            return randomBytes;
        }

        /// <summary>
        /// 随机生成nonce
        /// </summary>
        /// <returns></returns>
        public static string GenerateNonce()
        {
            byte[] buffer = new byte[16];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(buffer);
            }
            return Convert.ToBase64String(buffer).Replace("=", "");
        }
    }
}
