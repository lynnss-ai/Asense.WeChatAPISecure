using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asense.WeChatAPISecure.Signature.Models
{
    public class CommonBaseParam
    {
        [Newtonsoft.Json.JsonProperty("iv")]
        public string Iv { get; set; }
        [Newtonsoft.Json.JsonProperty("data")]
        public string Data { get; set; }
        [Newtonsoft.Json.JsonProperty("authtag")]
        public string AuthTag { get; set; }
    }
}
