using CRMManager.Contracts.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMManager.Web.Services.Interface
{
    public interface IContactFormService : IBaseService
    {
        Task<List<ContactForm>> GetFormsListAsync(int count, int page);
    }
}
