using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMManager.Web.Services.Interface
{
    public interface IBaseService
    {
        public Task<int> ItemsCountAsync();
    }
}
