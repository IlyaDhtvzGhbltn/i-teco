using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRMManager.Web.Entities
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }


        public virtual ContactForm ContactForm { get; set; }


        public bool IsActive { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
