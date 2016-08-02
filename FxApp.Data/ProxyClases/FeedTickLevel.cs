using System;
using System.Runtime.Serialization;

namespace FxApp.Data.ProxyClases
{
    // ReSharper disable once ClassNeverInstantiated.Global
    [DataContract]
    public class FeedTickLevel
    {
        public PriceType Type { get; set; }

        [DataMember(Name = "Type")]
        string PriceTypeString
        {
            get { return Enum.GetName(typeof(PriceType), this.Type); }
            set { this.Type = (PriceType)Enum.Parse(typeof(PriceType), value); }
        }

        [DataMember(Name = "Price")]
        public decimal Price { get; set; }

        [DataMember(Name = "Volume")]
        public decimal Volume { get; set; }
    }
}
