using SQLite;

namespace FxApp.Data.Models
{
    [Table("Ticks")]
    public class Tick
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        public string Symbol { get; set; }
    }
}
