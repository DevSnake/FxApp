





using System.IO;
using System.Linq;
using Windows.ApplicationModel.Contacts;
using Windows.Storage;
using FxApp.Base.Helpers;
using FxApp.Data.ProxyClases;
using FxApp.EasyCon;
using Microsoft.Data.Entity;

namespace FxApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public class DataContext: DbContext
    {
        public DbSet<FeedTickModel> FeedTickModel { get; set; }
        public DbSet<FeedTickLevelModel> FeedTickLevelModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFilePath = "FxDb.db";
            try
            {
                databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, databaseFilePath);
            }
            catch (InvalidOperationException) { }

            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
        }
        private readonly string _pathGetTisks;
        public DataContext()
        {
            var baseAddress = "https://cryptottdemowebapi.xbtce.net:8443";
            Proxy = new Proxy();
            BaseAddress = baseAddress;
            _pathGetTisks = "/api/v1/public/tick";
        }

        protected string BaseAddress { get; set; }

        protected IProxy Proxy { get;  set; }


        public async Task<List<FeedTickModel>> GetTicks()
        {
            List<FeedTickModel> list = new List<FeedTickModel>();
            var result = await Proxy.GetAsync<List<FeedTick>>(BaseAddress + _pathGetTisks);


            //if (result != null)
            //{
            //    var x = new FeedTickLevelModel();
            //    list.AddRange(result.Select(item => new FeedTickModel() {Symbol = item.Symbol,
            //        TimeStamp = HelperConverterUnixDate.DateTimeFromUnixTimestampSeconds(item.Timestamp),

            //        //BestAsk = new FeedTickLevelModel(),
            //        //BestBid = new FeedTickLevelModel()
            //    }));
            //}

            //await _connection.InsertAllAsync(list);
            //var query = _connection.Table<FeedTickModel>();
            //var ticks = await query.ToListAsync();
            //return ticks;
            return list;
        }
    }
}
