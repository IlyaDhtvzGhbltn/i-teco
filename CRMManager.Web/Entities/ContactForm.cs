using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRMManager.Web.Entities
{
    public class ContactForm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }


        [Required]
        public Guid ContactID { get; set; }
        [ForeignKey("ContactID")]
        public Contact Contact { get; set; }


        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }
        
        public virtual Phone Phone { get; set; }
    }
}
