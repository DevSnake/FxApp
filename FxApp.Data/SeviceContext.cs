



using System.Text;
using System.Threading.Tasks;

namespace FxApp.Data
{
    using EasyCon;
    using System.Collections.Generic;
    using ProxyClases;
    public class SeviceContext
    {
        private readonly string _pathGetTisks;

        protected string BaseAddress { get; set; }

        protected IProxy Proxy { get; set; }
        public SeviceContext(string baseAddress)
        {
            BaseAddress = baseAddress;
            _pathGetTisks = "/api/v1/public/tick";
            Proxy = new Proxy();
        }

        public async Task<List<FeedTick>> Api_Get_GetTicks()
        {
            return await Proxy.GetAsync<List<FeedTick>>(BaseAddress + _pathGetTisks);
        }
    }
}
