
namespace FxApp.EasyCon
{

    using System.Collections.Generic;
    using System.Text;

    public class Content : Dictionary<string, string>
    {
        public Content Headers { get; set; }

        public Encoding Encoding { get; set; }
    }
}
