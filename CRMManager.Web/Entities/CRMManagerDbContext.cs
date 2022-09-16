using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace CRMManager.Web.Entities
{
    public class CRMManagerDbContext : DbContext
    {
        public virtual DbSet<Call> Calls { get; set; }
        public virtual DbSet<Conference> Conferences { get; set; }
        public virtual DbSet<ContactForm> ContactForms { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
    }
}
