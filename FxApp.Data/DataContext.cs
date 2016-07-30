

namespace FxApp.Data
{
    using System;
    using SQLite;

    public class DataContext: IDisposable
    {
        private readonly SQLiteConnection _connection;

        public DataContext(string dBpath)
        {
            _connection=new SQLiteConnection(dBpath);
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
                    _connection.Dispose();
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

    }
}
