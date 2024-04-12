using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asense.WeChatAPISecure.Signature.Models;

namespace Asense.WeChatAPISecure.Signature.Signature
{
    public interface ISignatureService
    {
        /// <summary>
        /// RSA私钥签名
        /// </summary>
        /// <returns>签名</returns>
        Task<string> RsaSignature(RsaSignatureRequest request);

        /// <summary>
        /// RSA公钥验证签名
        /// </summary>
        /// <returns>true:验证成功;false:验证失败</returns>
        Task<bool> RsaVerifySignature(RsaVerifySignatureRequest request);
    }
}
