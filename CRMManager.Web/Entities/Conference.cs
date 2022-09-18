using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMManager.Web.Entities
{
    public class Conference
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string ConferenceTheme { get; set; }
        public DateTime ConferenceDate { get; set; }
        public List<Contact> Members { get; set; }
    }
}
