using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRMManager.Web.Entities
{
    public class Conference
    {
        [Required]
        [MaxLength(255)]
        public string ConferenceTheme { get; set; }
        public DateTime ConferenceDate { get; set; }
        public List<Contact> Members { get; set; }
    }
}
