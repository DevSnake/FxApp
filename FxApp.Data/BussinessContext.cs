
namespace FxApp.Data
{
    using SQLite;
    using System;
    public sealed class BussinessContext: IDisposable
    {
        private DataContext _context;
        private IAppMode _appMode;

        public BussinessContext(IAppMode appMode)
        {
            _context=new DataContext(appMode.DbPath);
            _appMode = appMode;
        }

        #region IDisposable Members

        private bool _disposed;
   

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed || disposing)
                return;
            _context?.Dispose();
            _disposed = true;
        }

        #endregion

        public void GetSymbols()
        {
            var db = new SQLiteAsyncConnection(_appMode.DbPath);
            
        }
    }
}
