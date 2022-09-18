using CRMManager.Web.Entities;
using CRMManager.Web.Infrastructure;
using CRMManager.Web.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contact = CRMManager.Contracts.Contacts.Contact;
using EditableContact = CRMManager.Contracts.Contacts.EditableContact;

namespace CRMManager.Web.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IFactory<CRMManagerDbContext> _dbFactory;

        public ContactsService(IFactory<CRMManagerDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task CreateNewContact(Contracts.Contacts.NewContact contact)
        {
            using (CRMManagerDbContext context = _dbFactory.Create())
            {
                context.Contacts.Add(
                    new Entities.Contact
                    {
                        RegistrationDate = DateTime.Now, 
                        IsActive = contact.IsActive
                    });
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteContact(Guid id)
        {
            using (CRMManagerDbContext context = _dbFactory.Create())
            {
                var contact = await context.Contacts.FirstOrDefaultAsync(x => x.ID == id);
                if (contact != null)
                {
                    context.Contacts.Remove(contact);
                    await context.SaveChangesAsync();
                }
                else 
                {
                    throw new NullReferenceException("Contact not found");
                }
            }
        }

        public async Task EditContact(Guid id, EditableContact contact)
        {
            using (CRMManagerDbContext context = _dbFactory.Create())
            {
                var contactDb = await context.Contacts
                    .Include(x => x.ContactForm)
                    .ThenInclude(x=>x.Phone)
                    .FirstOrDefaultAsync( x=>x.ID == id);

                if (contactDb != null)
                {
                    //if (contactDb.ContactForm == null) 
                    //{
                    //    contactDb.ContactForm = new ContactForm();
                    //    contactDb.ContactForm.ID = Guid.NewGuid();
                    //}
                    //contactDb.ContactForm.Name = contact.Name;
                    //contactDb.ContactForm.Surname = contact.Surname;
                    //contactDb.ContactForm.Phone = new Phone(contact.Phone);
                    //contactDb.ContactForm.Phone.ContactFormID = contactDb.ContactForm.ID;
                    contactDb.IsActive = contact.IsActive;

                    try
                    {
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex) 
                    {
                        throw;
                    }
                }
                else 
                {
                    throw new NullReferenceException("Contact not found");
                }
            }
        }

        public async Task<Contact> GetContactAsync(Guid contactID)
        {
            using (CRMManagerDbContext context = _dbFactory.Create())
            {
                var contactDb = await context.Contacts
                    .Include(x => x.ContactForm)
                    .ThenInclude(x => x.Phone)
                    .FirstOrDefaultAsync(x => x.ID == contactID);

                var contact = new Contact(contactDb.ID, contactDb.IsActive, contactDb.RegistrationDate);
                contact.ContactFormID = contactDb.ContactForm == null ? Guid.Empty : contactDb.ContactForm.ID;
                if (contactDb.ContactForm != null)
                {
                    contact.Name = contactDb.ContactForm.Name;
                    contact.Surname = contactDb.ContactForm.Surname;
                    if (contactDb.ContactForm.Phone != null)
                    {
                        contact.Phone = contactDb.ContactForm.Phone.Number;
                    }
                }
                return contact;
            }
        }

        public async Task<List<Contact>> GetContactsListAsync(int count, int page)
        {
            var contacts = new List<Contact>();
            using (CRMManagerDbContext context = _dbFactory.Create())
            {
                int skip = (page-1) * count;
                var contactsEntities = await context.Contacts
                    .Include(x => x.ContactForm)
                    .ThenInclude(x => x.Phone)
                    .Skip(skip).Take(count).ToListAsync();
                contactsEntities.ForEach(x =>
                {
                    var contact = new Contact(x.ID, x.IsActive, x.RegistrationDate);
                    contact.ContactFormID = x.ContactForm == null ? Guid.Empty : x.ContactForm.ID;
                    if (x.ContactForm != null)
                    {
                        contact.Name = x.ContactForm.Name;
                        contact.Surname = x.ContactForm.Surname;
                        if (x.ContactForm.Phone != null)
                        {
                            contact.Phone = x.ContactForm.Phone.Number;
                        }
                    }
                    contacts.Add(contact);
                });
            }
            return contacts;
        }

        public async Task<int> ItemsCountAsync()
        {
            using (CRMManagerDbContext context = _dbFactory.Create()) 
            {
                return await context.Contacts.CountAsync();
            }
        }
    }
}
