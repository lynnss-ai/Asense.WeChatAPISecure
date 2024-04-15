using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asense.WeChatAPISecure.Signature.Models;
using Asense.WeChatAPISecure.Signature.Utils;

namespace Asense.WeChatAPISecure.Signature.Signature
{
    public class SignatureService : ISignatureService
    {
        /// <summary>
        /// RSA私钥签名
        /// </summary>
        /// <returns>签名</returns>
        public async Task<string> RsaSignature(RsaSignatureRequest request)
        {
            string sign = RsaSignUtil.RsaSign(request.RsaPrivateKey, 
                $"{request.UrlPath}\n{request.AppID}|{request.timeStamp}|{request.Data}");
            return sign;
        }

        /// <summary>
        /// RSA公钥验证签名
        /// </summary>
        /// <returns>true:验证成功;false:验证失败</returns>
        public async Task<bool> RsaVerifySignature(RsaVerifySignatureRequest request)
        {
            bool isSuccess = RsaSignUtil.VerifySign(request.RsaPubKey, request.sign,
                $"{request.UrlPath}\n{request.AppID}\n{request.timeStamp}\n{request.Data}");
            return isSuccess;
        }
    }
}
