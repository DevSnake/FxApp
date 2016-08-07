namespace FxApp.EasyCon
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Security.Cryptography.Core;
    using Windows.Security.Cryptography;
    using System.Net.Http.Headers;
    using System.Net;
    using System.Threading;

    internal class HMACHttpClientHandler: HttpClientHandler
    {
        private readonly string _webApiId;
        private readonly string _webApiKey;
        private readonly string _webApiSecret;

        public HMACHttpClientHandler(string webApiId, string webApiKey, string webApiSecret)
        {
            const string message = "Account Web API methods requeies valid Web API token (Id, Key, Secret)!";
            if (string.IsNullOrEmpty(webApiId))
                throw new ArgumentNullException("webApiId", message);
            if (string.IsNullOrEmpty(webApiKey))
                throw new ArgumentNullException("webApiKey", message);
            if (string.IsNullOrEmpty(webApiSecret))
                throw new ArgumentNullException("webApiSecret", message);

            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            _webApiId = webApiId;
            _webApiKey = webApiKey;
            _webApiSecret = webApiSecret;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var timestamp = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            var content = (request.Content != null) ? await request.Content.ReadAsStringAsync() : "";
            var signature = timestamp + _webApiId + _webApiKey + request.Method.Method + request.RequestUri + content;

            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(_webApiSecret);

            var hash = GetSHA256Key(keyByte,signature);

            request.Headers.Authorization = new AuthenticationHeaderValue("HMAC", string.Format("{0}:{1}:{2}:{3}", _webApiId, _webApiKey, timestamp, hash));
            return await base.SendAsync(request, cancellationToken);
        }

        private string GetSHA256Key(byte[] secretKey, string value)
        {
            var objMacProv = MacAlgorithmProvider.OpenAlgorithm(MacAlgorithmNames.HmacSha256);
            var hash = objMacProv.CreateHash(secretKey.AsBuffer());
            hash.Append(CryptographicBuffer.ConvertStringToBinary(value, BinaryStringEncoding.Utf8));
            return CryptographicBuffer.EncodeToBase64String(hash.GetValueAndReset());
        }
    }
}
