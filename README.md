# Asense.WeChatAPISecure
### C# 实现微信服务端api签名
- [👉👉👉微信服务端api签名文档](https://developers.weixin.qq.com/miniprogram/dev/OpenApiDoc/getting_started/api_signature.html)
- [👉👉👉微信服务端api签名支持接口看这里](https://developers.weixin.qq.com/miniprogram/dev/OpenApiDoc/)

#### 代码中涉及到的内容为数据加解密 | 生成签名和验证签名 代码片段如下:
```
- 加密
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

- 解密
using AesGcm aesGcm = new AesGcm(aesKey);
byte[] decryptText = new byte[data.Length];

aesGcm.Decrypt(iv, data, authTag, decryptText, aad);
return Encoding.UTF8.GetString(decryptText);

- 数据签名
using RSA rsa = RSA.Create();
rsa.ImportPkcs8PrivateKey(keyBytes, out _);
byte[] sig = rsa.SignData(payloadBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
sign = Convert.ToBase64String(sig);

- 验证签名
X509Certificate2 cert = new X509Certificate2(keyBytes);
using (RSA rsa = cert.GetRSAPublicKey())
{
    isSuccess = rsa.VerifyData(payloadBytes, signBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
}
```