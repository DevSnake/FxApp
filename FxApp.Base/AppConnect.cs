

namespace FxApp.Base
{
    using System.Collections.Generic;

    public class AppConnect:Dictionary<ConnectMode,string>
    {
        public AppConnect()
        {
            Add(ConnectMode.BaseURL, "https://cryptottdemowebapi.xbtce.net:8443");
        }
    }
}
