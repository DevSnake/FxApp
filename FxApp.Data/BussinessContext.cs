

namespace FxApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public sealed class BussinessContext: IDisposable
    {
        private List<FeedTickModel> Ticks { get; set; }

        private readonly DataContext _context;
        private IAppMode _appMode;

        public BussinessContext(IAppMode appMode)
        {
            _appMode = appMode;
            _context =new DataContext(appMode.DbPath);
            
        }

        public async Task CreateDatabase()
        {
            await _context.CreateDatabase();
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

        public async Task<FeedTickModel> CreateTick(string symbol)
        {
            var tick = new FeedTickModel()
            {
               Symbol = symbol
            };

            var countItem=await _context.AddTick(tick);
            return countItem == 0 ? null : tick;
        }
    }
}
