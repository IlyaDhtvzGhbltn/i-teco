using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRMManager.Web.Entities
{
    public class ContactForm
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public Phone Phone { get; set; }
    }
}
