
using System.Diagnostics;
using System.IO;

namespace FxApp.Base
{
    using BlackBee.Common.Petterns;
    using Data;

    public class AppMode:Singleton<AppMode>,IAppMode
    {
        private AppMode()
        {
            string dbRootPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            Debug.Write(dbRootPath);
            DbPath = "FxDb.db";  //Path.Combine(dbRootPath, "FxDb.db");
        }

        public string DbPath { get; set; }

        public ConnectMode ConnectMode { get; set; }
        protected AppConnect AppConnect { get; set; }
    }
}
