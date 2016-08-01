using System.Text;
using System.Threading.Tasks;

namespace FxApp.EasyCon
{
    public interface IHelperStreamReader
    {
        T ReadObject<T>(string responce, Encoding encoding = null) where T : class;
        Task<T> ReadObjectAsync<T>(string responce, Encoding encoding = null) where T : class;

    }
}
