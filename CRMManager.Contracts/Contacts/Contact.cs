using System;

namespace CRMManager.Contracts.Contacts
{
    public class Contact
    {
        public Guid ID { get; set; }
        public Guid ContactFormID { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }


        public Contact()
        {

        }

        public Contact(Guid ID, bool isActive, DateTime registrationDate)
        {
            this.ID = ID;
            this.IsActive = isActive;
            this.RegistrationDate = registrationDate;
        }
    }
}
