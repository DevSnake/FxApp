using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FxApp.EasyCon
{
    public class HelperStreamReader : IHelperStreamReader
    {

        #region  implementation IHelperStreamReader

        public T ReadObject<T>(string responce, Encoding encoding = null) where T : class
        {
            //var responce = new StreamReader(stream, encoding ?? Encoding.UTF8).ReadToEnd();

            if (encoding == null)
                encoding = Encoding.UTF8;

            var bytes = encoding.GetBytes(responce);
            using (var streamMemory = new MemoryStream(bytes))
            using (var reader = new StreamReader(streamMemory, Encoding.UTF8))
            {
                return Serializer.DeserializeDataContractRequest<T>(reader.ReadToEnd());
            }
        }

        
        public async Task<T> ReadObjectAsync<T>(string responce, Encoding encoding = null) where T : class
        {
            //var responce = new StreamReader(stream, encoding ?? Encoding.UTF8).ReadToEnd();

            if (encoding == null)
                encoding = Encoding.UTF8;

            var bytes = encoding.GetBytes(responce);
            using (var streamMemory = new MemoryStream(bytes))
            using (var reader = new StreamReader(streamMemory, Encoding.UTF8))
            {
                return await Serializer.DeserializeDataContractRequestAsync<T>(reader.ReadToEnd());
            }
        }

        #endregion

    }
}
