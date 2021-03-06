﻿namespace FxApp.Data.ProxyClases
{
    using System.Runtime.Serialization;

    [DataContract]
    [KnownType(typeof(FeedTickLevel))]
    
    public class FeedTick
    {
      
        [DataMember(Name = "Symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "Timestamp")]
        public long Timestamp { get; set; }

        [DataMember(Name = "BestBid")]
        public FeedTickLevel BestBid { get; set; }

        [DataMember(Name = "BestAsk")]
        public FeedTickLevel BestAsk { get; set; }
    }
}
