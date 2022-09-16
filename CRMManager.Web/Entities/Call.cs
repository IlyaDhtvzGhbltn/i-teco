using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMManager.Web.Entities
{
    public class Call
    {
        public Phone Сaller { get; set; }
        public Phone CallReceiver { get; set; }
        public DateTime CallDate { get; set; }
        public int CallTimeSec { get; set; }
    }
}
