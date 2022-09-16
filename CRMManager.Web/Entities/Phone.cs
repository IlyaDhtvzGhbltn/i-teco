using System;
using System.ComponentModel.DataAnnotations;


namespace CRMManager.Web.Entities
{
    public class Phone
    {
        [Required]
        [MaxLength(17)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("\\+\\d-\\d{3}-\\d{3}-\\d{2}-\\d{2}")]
        public string Number { get; set; }

        public bool IsActive { get; set; }

        public DateTime DeactivationDate { get; set; }

        public string DeactivationReason { get; set; }
    }
}
