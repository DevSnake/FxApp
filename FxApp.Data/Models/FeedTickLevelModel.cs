namespace FxApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class FeedTickLevelModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FeedTickLevelId { get; set; }
        public Guid FeedTickId { get; set; }
        public virtual FeedTickModel FeedTickModel { get; set; }
        public PriceTypeModel Type { get; set; }

        
        public decimal Price { get; set; }

       
        public decimal Volume { get; set; }
    }
}
