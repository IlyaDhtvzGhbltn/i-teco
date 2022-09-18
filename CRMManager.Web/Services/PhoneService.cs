using CRMManager.Web.Infrastructure;
using CRMManager.Web.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMManager.Web.Services
{
    public class PhoneService : IPhoneService
    {
        public Task<Pagination> GetPagination(int count, int page)
        {
            throw new NotImplementedException();
        }

        public Task<int> ItemsCountAsync()
        {
            throw new NotImplementedException();
        }
    }
}
