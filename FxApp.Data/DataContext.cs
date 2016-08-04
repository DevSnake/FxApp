

namespace FxApp.Data
{
    using ProxyClases;
    using System.IO;
    using System.Linq;
    using Windows.Storage;
    using Microsoft.Data.Entity;
    using System;
    using System.Collections.Generic;
    using Models;

    public class DataContext: DbContext
    {
        public DataContext():base(){}
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
        


        public List<FeedTickModel> GetTicks()
        {
            return FeedTickModel.ToList();
        }

        public void AddTicksRange(IEnumerable<FeedTick> serviceRes)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();

            foreach (var serviceItem in serviceRes)
            {
                //ASK
                FeedTickLevelModel feedTickLevelModelAsk = new FeedTickLevelModel()
                {
                    FeedTickLevelId = Guid.NewGuid(),
                    Type = PriceTypeModel.Ask
                };
                if (serviceItem.BestAsk != null)
                {
                    feedTickLevelModelAsk.Price = serviceItem.BestAsk.Price;
                    feedTickLevelModelAsk.Volume = serviceItem.BestAsk.Volume;

                }
                FeedTickLevelModel.Add(feedTickLevelModelAsk);


                //BID
                FeedTickLevelModel feedTickLevelModelBid = new FeedTickLevelModel()
                {
                    FeedTickLevelId = Guid.NewGuid(),
                    Type = PriceTypeModel.Bid
                };
                if (serviceItem.BestAsk != null)
                {
                    feedTickLevelModelBid.Price = serviceItem.BestAsk.Price;
                    feedTickLevelModelBid.Volume = serviceItem.BestAsk.Volume;

                }
                FeedTickLevelModel.Add(feedTickLevelModelBid);

                this.FeedTickModel.Add(new FeedTickModel()
                {
                    FeedTickId = Guid.NewGuid(),
                    Levels = new List<FeedTickLevelModel>() {feedTickLevelModelBid, feedTickLevelModelAsk}
                });
                SaveChanges();
            }
        }
    }
}
