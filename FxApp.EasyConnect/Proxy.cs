namespace FxApp.EasyConnect
{
    using System;
    using System.Net.Http;

    public class Proxy: IProxy
    {
        public HttpClient HttpClient { get; private set; }
        public Proxy()
        {
            CreateHandler();
        }
        public void CreateHandler(HttpMessageHandler handler = null)
        {
            HttpClient = handler == null ? new HttpClient() { Timeout = new TimeSpan(0, 0, 60) } : new HttpClient(handler);
        }
    }
}
