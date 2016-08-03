


using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FxApp.Data.Models
{
    using System.Collections.Generic;

    public class FeedTickModel
    {
        public FeedTickModel()
        {
            Levels=new HashSet<FeedTickLevelModel>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FeedTickModel_ID { get; set; }

        public string Symbol { get; set; }
        public DateTime Timestamp { get; set; }

        public virtual ICollection<FeedTickLevelModel> Levels { get; set; }
    }
}
