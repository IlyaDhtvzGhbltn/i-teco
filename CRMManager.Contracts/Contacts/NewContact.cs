using System;
using System.Collections.Generic;
using System.Text;

namespace CRMManager.Contracts.Contacts
{
    public class NewContact
    {
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
