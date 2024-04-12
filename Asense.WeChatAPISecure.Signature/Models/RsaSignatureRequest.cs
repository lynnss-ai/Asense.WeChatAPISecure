using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asense.WeChatAPISecure.Signature.Models
{
    public class RsaSignatureRequest
    {
        /// <summary>
        /// 接口URL地址
        /// </summary>
        public string UrlPath { get; set; }
        /// <summary>
        /// 微信APPID
        /// </summary>
        public string AppID { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public long timeStamp { get; set; }
        /// <summary>
        /// RSA密钥
        /// </summary>
        public string RsaPrivateKey { get; set; }
        /// <summary>
        /// 待签名的数据
        /// </summary>
        public string Data { get; set; }
    }
}
