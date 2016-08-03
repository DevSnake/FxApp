using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FxApp.Data.Models
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Windows.ApplicationModel.Contacts;

    public class FeedTickLevelModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FeedTickLevelModel_ID { get; set; }
        public Guid FeedTickModel_ID { get; set; }
        public virtual FeedTickModel FeedTickModel { get; set; }
        public PriceType Type { get; set; }
    }
}
