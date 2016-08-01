





using System.Linq;
using FxApp.Data.ProxyClases;
using FxApp.EasyCon;

namespace FxApp.Data
{
    using System;
    using SQLite;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public class DataContext: IDisposable
    {
        private readonly SQLiteAsyncConnection _connection;
        private readonly string _pathGetTisks;
        public DataContext(string dBpath)
        {
            var baseAddress = "https://cryptottdemowebapi.xbtce.net:8443";
            _connection =new SQLiteAsyncConnection(dBpath);
            Proxy = new Proxy();
            BaseAddress = baseAddress;
            _pathGetTisks = "/api/v1/public/tick";
        }

        protected string BaseAddress { get; set; }

        protected IProxy Proxy { get;  set; }

        #region IDisposable
        /// <summary>
        /// Будет нам помогать выяснять вызывался ли уже метод Dispose()
        /// </summary>
        private bool _disposed = false;

        public void Dispose()
        {
            //Сделаем вызов нашего метода True показывает что очистка иницирована пользователем объекта
            Cleanup(true);

            //Подавление финализации
            GC.SuppressFinalize(this);
        }

        private void Cleanup(bool disposing)
        {
            //Выполнялась ли очистка
            if (!_disposed)
            {
                
                //Высвобождаем все управляемые ресурсы
                if (disposing)
                {
                    //_connection.Dispose();
                }

                //Очистка неуправляемых ресурсов
            }
            _disposed = true;
        }

        ~DataContext()
        {
            //Вызов был иницирован сборщиком мусора
            Cleanup(false);
        }

        #endregion

        public async Task CreateDatabase()
        {
           await _connection.CreateTableAsync<FeedTickModel>();
        }

        public async Task<int> AddTick(FeedTickModel feedTickModel)
        {
           return await _connection.InsertAsync(feedTickModel);
        }

        public async Task<List<FeedTickModel>> GetTicks()
        {
            List<FeedTickModel> list = new List<FeedTickModel>();
            var result = await Proxy.GetAsync<List<FeedTick>>(BaseAddress + _pathGetTisks);

            if (result != null)
            {
                list.AddRange(result.Select(item => new FeedTickModel() {Symbol = item.Symbol}));
            }
            //var query = _connection.Table<FeedTickModel>();
            //var ticks = await query.ToListAsync();
            //return ticks;
            return list;
        }
    }
}
