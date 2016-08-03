using SQLite;

namespace FxApp.Data.Models
{
    [Table("FeedTickLevel")]

    public class FeedTickLevelModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
