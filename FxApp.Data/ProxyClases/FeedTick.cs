using System.Runtime.Serialization;

namespace FxApp.Data.ProxyClases
{
    [DataContract]
    public class FeedTick
    {
        [DataMember(Name = "Symbol")]
        public string Symbol { get; set; }
        [DataMember(Name = "Timestamp")]
        public long Timestamp { get; set; }
        //public FeedTickLevel BestBid { get; set; }
        //public FeedTickLevel BestAsk { get; set; }
    }
}
