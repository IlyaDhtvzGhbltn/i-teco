using CRMManager.Contracts.Form;
using CRMManager.Web.Entities;
using CRMManager.Web.Infrastructure;
using CRMManager.Web.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMManager.Web.Services
{
    public class ContactFormService : IContactFormService
    {
        private readonly IFactory<CRMManagerDbContext> _dbFactory;

        public ContactFormService(IFactory<CRMManagerDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }


        public async Task<List<Contracts.Form.ContactForm>> GetFormsListAsync(int count, int page)
        {
            var list = new List<Contracts.Form.ContactForm>();

            using (CRMManagerDbContext context = _dbFactory.Create())
            {
                int skip = (page - 1) * count;
                var forms = await context.ContactForms
                    .Skip(skip)
                    .Take(count)
                    .ToListAsync();
                forms.ForEach(x => 
                {
                    list.Add(new Contracts.Form.ContactForm
                    {
                        ID = x.ID, 
                        BirthDate = x.BirthDate, 
                        Name = x.Name, 
                        Surname = x.Surname
                    }) ;
                });
            }
            return list;
        }

        public async Task<Pagination> GetPagination(int count, int page)
        {
            int totalItems = await this.ItemsCountAsync();
            Pagination p = new Pagination(totalItems, count, page);
            return p;
        }

        public async Task<int> ItemsCountAsync()
        {
            using (CRMManagerDbContext context = _dbFactory.Create())
            {
                return await context.ContactForms.CountAsync();
            }
        }
    }
}
