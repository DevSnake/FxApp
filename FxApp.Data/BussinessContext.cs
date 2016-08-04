namespace FxApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;
    using Microsoft.Data.Entity;

    public sealed class BussinessContext: IDisposable
    {
        private readonly SeviceContext _seviceContext;
        private readonly DataContext _context;
        private IAppMode _appMode;

        public BussinessContext(IAppMode appMode)
        {
            _appMode = appMode;
            _context =new DataContext();
            _context.Database.ApplyMigrations();
            _context.Database.EnsureCreated();


            _seviceContext=new SeviceContext(appMode.ServiceBaseUrl);
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
            var serviceRes=await _seviceContext.Api_Get_GetTicks();

            if (serviceRes == null) return _context.GetTicks();

            _context.AddTicksRange(serviceRes);

            return _context.GetTicks();
        }

        #endregion

    }
}
