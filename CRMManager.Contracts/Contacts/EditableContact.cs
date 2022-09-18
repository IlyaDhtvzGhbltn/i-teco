using System;
using System.Collections.Generic;
using System.Text;

namespace CRMManager.Contracts.Contacts
{
    public class EditableContact
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
    }
}
