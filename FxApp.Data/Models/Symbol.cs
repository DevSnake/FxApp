using SQLite;

namespace FxApp.Data.Models
{
    [Table("Symbols")]
    public class Symbol
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
    }
}
