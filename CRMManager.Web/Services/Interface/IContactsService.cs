using CRMManager.Contracts;
using CRMManager.Contracts.Contacts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contact = CRMManager.Contracts.Contacts.Contact;
using NewContact = CRMManager.Contracts.Contacts.NewContact;

namespace CRMManager.Web.Services.Interface
{
    public interface IContactsService : IBaseService
    {
        Task<List<Contact>> GetContactsListAsync(int count, int page);
        Task<Contact> GetContactAsync(Guid contactID);
        Task CreateNewContact(NewContact contact);
        Task DeleteContact(Guid id);
        Task EditContact(Guid id, EditableContact contact);
    }
}
