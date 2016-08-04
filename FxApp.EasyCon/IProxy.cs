
using System.Threading.Tasks;

namespace FxApp.EasyCon
{
    using System.Text;


    public interface IProxy
    {
        Task<TResult> GetAsync<TResult>(string uri, Encoding encoding = null)
            where TResult : class;
    }
}
