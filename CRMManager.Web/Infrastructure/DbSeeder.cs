using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMManager.Web.Infrastructure
{
    public class DbSeeder
    {
        private readonly MigrationBuilder _migrationBuilder;
        string insertIntoContact = "insert into Contacts (ID, IsActive, RegistrationDate) values('{0}', 1, GETDATE())";
        string insertIntoContactForm = "insert into ContactForms(ID, Name, Surname, BirthDate, ContactID) values('{0}', '{1}', '{1}', '{2}', '{3}')";

        public DbSeeder(MigrationBuilder migrationBuilder)
        {
            _migrationBuilder = migrationBuilder;
        }

        public void Seed() 
        {
            Random rnd = new Random(DateTime.UtcNow.Millisecond);

            for (int i = 0; i < 1000; i++)
            {
                Guid contactID = Guid.NewGuid();
                _migrationBuilder.Sql(string.Format(insertIntoContact, contactID));

                if (i % 3 == 0)
                {
                    Guid contactFormID = Guid.NewGuid();
                    string name = contactFormID.GetHashCode().ToString();
                    string date = DateTime.UtcNow.AddYears(rnd.Next(-50, -10)).ToString("yyyy");

                    _migrationBuilder.Sql(string.Format(insertIntoContactForm, contactFormID, name, date, contactID));
                }
            }
        }
    }
}
