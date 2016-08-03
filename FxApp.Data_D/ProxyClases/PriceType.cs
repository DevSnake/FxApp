using System.Runtime.Serialization;

namespace FxApp.Data.ProxyClases
{
    [DataContract(Name = "Type")]
    public enum PriceType
    {
        [EnumMember]
        // ReSharper disable once InconsistentNaming
        Ask,
        [EnumMember]
        // ReSharper disable once InconsistentNaming
        Bid
    }
}
