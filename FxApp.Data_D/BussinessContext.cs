



namespace FxApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;
    using Microsoft.Data.Entity;

    public sealed class BussinessContext: IDisposable
    {
        private readonly DataContext _context;
        private IAppMode _appMode;

        public BussinessContext(IAppMode appMode)
        {
            _appMode = appMode;
            _context =new DataContext();
            _context.Database.ApplyMigrations();

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

        public async Task<List<FeedTickModel>> GetTicks()
        {

            return await _context.GetTicks();
        }

        #endregion

    }
}
