




using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Windows.ApplicationModel.Contacts;

namespace FxApp.Data.Models
{

    public class FeedTickLevelModel
    {
        [Key]
        public string Skill { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
