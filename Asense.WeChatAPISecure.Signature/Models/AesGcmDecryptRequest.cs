using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asense.WeChatAPISecure.Signature.Models
{
    public class AesGcmDecryptRequest
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
        /// AesKey
        /// </summary>
        public string AesKey { get; set; }
        /// <summary>
        /// AseSn
        /// </summary>
        public string AesSn { get; set; }
        /// <summary>
        /// 时间戳[秒级]
        /// </summary>
        public long timeStamp { get; set; }

        /// <summary>
        /// 响应的加密数据
        /// </summary>
        public CommonBaseParam commonBaseParam { get; set; }
    }
}
