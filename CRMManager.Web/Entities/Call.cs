using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRMManager.Web.Entities
{
    public class Call
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public Phone Сaller { get; set; }
        public Phone CallReceiver { get; set; }
        public DateTime CallDate { get; set; }
        public int CallTimeSec { get; set; }
    }
}
