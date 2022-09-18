using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace CRMManager.Web.Entities
{
    public class CRMManagerDbContext : DbContext
    {
        public virtual DbSet<Call> Calls { get; set; }
        public virtual DbSet<Conference> Conferences { get; set; }
        public virtual DbSet<ContactForm> ContactForms { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }


        public CRMManagerDbContext(DbContextOptions<CRMManagerDbContext> opt) : base(opt)
        {
            //base.Database.EnsureDeleted();
            var migrator = base.Database.GetService<IMigrator>();
            migrator.Migrate();
        }
    }
}