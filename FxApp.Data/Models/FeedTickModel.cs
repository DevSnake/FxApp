using System;
using SQLite;

namespace FxApp.Data.Models
{
    [Table("FeedTick")]
    public class FeedTickModel
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        public string Symbol { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
