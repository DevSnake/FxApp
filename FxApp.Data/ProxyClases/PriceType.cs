
namespace FxApp.Data.ProxyClases
{
    using System.Runtime.Serialization;

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
