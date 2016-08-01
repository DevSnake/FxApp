

namespace FxApp.EasyCon
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;

    internal class EncodedContent : ByteArrayContent
    {
        public EncodedContent(IEnumerable<KeyValuePair<string, string>> nameValueCollection, Encoding encoding)
            : base(GetContentByteArray(nameValueCollection, encoding))
        {
            Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }

        private static byte[] GetContentByteArray(IEnumerable<KeyValuePair<string, string>> nameValueCollection,
            Encoding encoding)
        {
            var stringBuilder = new StringBuilder();
            foreach (var keyValuePair in nameValueCollection)
            {
                //if (stringBuilder.Length > 0)
                //    stringBuilder.Append('&');
                //stringBuilder.Append(keyValuePair.Key);
                //stringBuilder.Append('=');
                //stringBuilder.Append(keyValuePair.Value);

                if (stringBuilder.Length == 0)
                    stringBuilder.Append('{');
                else
                {
                    stringBuilder.Append(',');
                }
                stringBuilder.Append('\"');
                stringBuilder.Append(keyValuePair.Key);
                stringBuilder.Append('\"');
                stringBuilder.Append(':');
                stringBuilder.Append('\"');
                stringBuilder.Append(keyValuePair.Value);
                stringBuilder.Append('\"');
            }
            stringBuilder.Append('}');

            return encoding.GetBytes(stringBuilder.ToString());
        }
    }
}
