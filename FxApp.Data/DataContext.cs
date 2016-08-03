





using System.Diagnostics;
using System.IO;
using System.Linq;
using Windows.ApplicationModel.Contacts;
using Windows.Storage;
using FxApp.Base.Helpers;
using FxApp.Data.ProxyClases;
using FxApp.EasyCon;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Internal;

namespace FxApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public class DataContext: DbContext
    {
        public DataContext():base()
        {
            var baseAddress = "https://cryptottdemowebapi.xbtce.net:8443";
            Proxy = new Proxy();
            BaseAddress = baseAddress;
            _pathGetTisks = "/api/v1/public/tick";
            
        }
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
      

        protected string BaseAddress { get; set; }

        protected IProxy Proxy { get;  set; }


        public async Task<List<FeedTickModel>> GetTicks()
        {
            List<FeedTickModel> list = new List<FeedTickModel>();
            var result = await Proxy.GetAsync<List<FeedTick>>(BaseAddress + _pathGetTisks);

            this.Database.EnsureDeleted();
            SaveChanges();
            this.Database.EnsureCreated();
            SaveChanges();

            foreach (var item in result)
            {
                List<FeedTickLevelModel> feedTickLevelModels = new List<FeedTickLevelModel>();

                FeedTickLevelModel FeedTickLevelModelBid = new FeedTickLevelModel()
                {
                    FeedTickLevelModel_ID = Guid.NewGuid(),
                    Type = PriceType.Bid
                };
                if (item.BestAsk != null)
                {
                    FeedTickLevelModelBid.Price = item.BestAsk.Price;
                    FeedTickLevelModelBid.Volume = item.BestAsk.Volume;
                }
                    this.FeedTickLevelModel.Add(FeedTickLevelModelBid);
                feedTickLevelModels.Add(FeedTickLevelModelBid);


                FeedTickLevelModel FeedTickLevelModelAsk= new FeedTickLevelModel()
                {
                    FeedTickLevelModel_ID = Guid.NewGuid(),
                    Type = PriceType.Ask
                };
                if (item.BestAsk != null)
                {
                    FeedTickLevelModelAsk.Price = item.BestAsk.Price;
                    FeedTickLevelModelAsk.Volume = item.BestAsk.Volume;
                }
                this.FeedTickLevelModel.Add(FeedTickLevelModelAsk);
                feedTickLevelModels.Add(FeedTickLevelModelAsk);

                this.FeedTickModel.Add(new FeedTickModel()
                {

                  FeedTickModel_ID = Guid.NewGuid(),
                   Symbol = item.Symbol,
                   Timestamp = HelperConverterUnixDate.DateTimeFromUnixTimestampSeconds(item.Timestamp),
                   Levels = feedTickLevelModels                 
                });
                
            }
            
            this.SaveChanges();
            
            

           
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
            return this.FeedTickModel.ToList();
        }
    }
}
