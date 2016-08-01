
namespace FxApp.EasyCon
{
    using System.Text;
    using System.Threading.Tasks;

    public interface IProxy
    {
        Task<TResult> GetAsync<TResult>(string uri, Encoding encoding = null)
            where TResult : class;
    }
}
