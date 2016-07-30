

namespace FxApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public sealed class BussinessContext: IDisposable
    {
        private List<Tick> Ticks { get; set; }

        private readonly DataContext _context;
        private IAppMode _appMode;

        public BussinessContext(IAppMode appMode)
        {
            _context=new DataContext(appMode.DbPath);
            _appMode = appMode;
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

        public async Task<List<Tick>> GetTicks()
        {
            return await _context.GetTicks();
        }

        #endregion

        public async Task<Tick> CreateTick(string symbol)
        {
            var tick = new Tick()
            {
               Symbol = symbol
            };

            var countItem=await _context.AddTick(tick);
            return countItem == 0 ? null : tick;
        }
    }
}
