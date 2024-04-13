using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Asense.WeChatAPISecure.Signature.Models;
using Asense.WeChatAPISecure.Signature.Utils;
using Newtonsoft.Json;

namespace Asense.WeChatAPISecure.Signature.Encryption
{
    public class EncryptService : IEncryptService
    {
        /// <summary>
        /// AES256_GCM数据加密
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AesGcmEncryptResponse> AesGcmEncryption(AesGcmEncryptRequest request)
        {
            var dataDicObj = new Dictionary<string, object>();
            if (request.Data != null)
            {
                string dataJson = JsonConvert.SerializeObject(request.Data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                dataDicObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(dataJson);
            }
            dataDicObj["_n"] = RandomUtil.GenerateNonce();
            dataDicObj["_appid"] = request.AppID;
            dataDicObj["_timestamp"] = request.timeStamp;

            string data = JsonConvert.SerializeObject(dataDicObj);

            byte[] ivBytes = RandomUtil.GenerateRandomBytes(12);
            string aad = $"{request.UrlPath}|{request.AppID}|{request.timeStamp}|{request.AesSn}";
            byte[] aesKeyBytes = Convert.FromBase64String(request.AesKey);
            byte[] aadBytes = Encoding.UTF8.GetBytes(aad);
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            return AesGcmUtil.AesGcmEncryptData(aadBytes, aesKeyBytes, ivBytes, dataBytes);

        }

        /// <summary>
        /// AES256_GCM数据解密
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<T> AesGcmDecrypt<T>(AesGcmDecryptRequest request)
        {
            string aad = $"{request.UrlPath}|{request.AppID}|{request.timeStamp}|{request.AesSn}";
            byte[] aadBytes = Encoding.UTF8.GetBytes(aad);
            byte[] aesKeyBytes = Convert.FromBase64String(request.AesKey);
            byte[] ivBytes = Convert.FromBase64String(request.commonBaseParam.Iv);
            byte[] dataBytes = Convert.FromBase64String(request.commonBaseParam.Data);
            byte[] authTagBytes = Convert.FromBase64String(request.commonBaseParam.AuthTag);

            string resultData = AesGcmUtil.AesGcmDecryptData(aadBytes, aesKeyBytes, ivBytes, dataBytes, authTagBytes);

            var result = JsonConvert.DeserializeObject<T>(resultData);

            return result;

        }
    }
}
