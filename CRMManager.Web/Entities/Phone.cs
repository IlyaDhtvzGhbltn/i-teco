using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRMManager.Web.Extensions;

namespace CRMManager.Web.Entities
{
    public class Phone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }


        [Required]
        public Guid ContactFormID { get; set; }
        [ForeignKey("ContactFormID")]
        public ContactForm Contact { get; set; }


        [Required]
        [MaxLength(17)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("\\+\\d-\\d{3}-\\d{3}-\\d{2}-\\d{2}")]
        public string Number { get; set; }

        public bool IsActive { get; set; }

        public DateTime DeactivationDate { get; set; }

        public string DeactivationReason { get; set; }

        public Phone(string number)
        {
            bool valid = this.Validate(number);
            ID = Guid.NewGuid();
            if (valid)
            {
                Number = number;
            }
            else 
            {
                throw new ArgumentException("Invalid phone number");
            }
        }
    }
}
