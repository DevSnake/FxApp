

using System.Net.Http.Headers;

namespace FxApp.EasyCon
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.IO;
    using System.Net;

    public class Proxy : IProxy
    {
        protected HttpClient HttpClient { get; set; }
        public IHelperStreamReader HelperStreamReader { get; private set; }
        public Proxy()
        {
            CreateHandler();
            HelperStreamReader = new HelperStreamReader();
        }

        public void CreateHandler()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            HttpClient = new HttpClient(handler) { Timeout = new TimeSpan(0, 0, 60) };
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            //HttpClient = handler == null ? new HttpClient() {Timeout = new TimeSpan(0, 0, 60)} : new HttpClient(handler);
            //HttpClient.DefaultRequestHeaders
            //    .Accept
            //    .Add(new MediaTypeWithQualityHeaderValue("application/json")); //ACCEPT header
        }

        public async Task<TResult> GetAsync<TResult>(string uri, Encoding encoding = null) where
            TResult : class
        {
            //content = content ?? new Content();
            //var encodedContent = new EncodedContent(content, encoding);
            encoding = encoding ?? Encoding.UTF8;
            
            Debug.WriteLine("### Dev Windows Phone Log : >> url =  " + uri);
            
            
            var response = await HttpClient.GetAsync(uri);
            
            var result = await GetObject<TResult>(response, encoding);

            return result;
        }

        private async Task<TResult> GetObject<TResult>(HttpResponseMessage response, Encoding encoding = null)
            where TResult : class
        {
            if (response.StatusCode != HttpStatusCode.OK)
                throw new HttpRequestException(response.StatusCode.ToString());

            var stream = await response.Content.ReadAsStreamAsync();

            var responce = new StreamReader(stream, encoding ?? Encoding.UTF8).ReadToEnd();

#if DEBUG
            Debug.WriteLine("### Dev Windows Phone Log : >> Method ReadObject is stream = " + responce);
#endif
            return HelperStreamReader.ReadObject<TResult>(responce);
        }
    }
}
