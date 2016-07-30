

using System.Collections.Generic;
using System.Threading.Tasks;
using FxApp.Data.Models;

namespace FxApp.Data
{
    using System;
    using SQLite;
    

    public class DataContext: IDisposable
    {
        private readonly SQLiteAsyncConnection _connection;

        public DataContext(string dBpath)
        {
            _connection=new SQLiteAsyncConnection(dBpath);
        }

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
           await _connection.CreateTableAsync<Tick>();
        }

        public async Task<int> AddTick(Tick tick)
        {
           return await _connection.InsertAsync(tick);
        }

        public async Task<List<Tick>> GetTicks()
        {
            var query = _connection.Table<Tick>();
            var ticks = await query.ToListAsync();
            return ticks;
        }
    }
}
