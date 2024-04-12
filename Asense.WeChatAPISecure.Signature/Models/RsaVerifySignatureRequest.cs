using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asense.WeChatAPISecure.Signature.Models
{
    public class RsaVerifySignatureRequest
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
        /// 响应时间戳
        /// </summary>
        public long timeStamp { get; set; }
        /// <summary>
        /// 响应签名
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// RSA公钥
        /// </summary>
        public string RsaPubKey { get; set; }
        /// <summary>
        /// 响应数据
        /// </summary>
        public string Data { get; set; }
    }
}
