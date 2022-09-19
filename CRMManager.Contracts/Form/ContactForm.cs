using System;
using System.Collections.Generic;
using System.Text;

namespace CRMManager.Contracts.Form
{
    public class ContactForm
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
