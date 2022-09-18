using CRMManager.Contracts.Form;
using CRMManager.Web.Infrastructure;
using CRMManager.Web.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMManager.Web.Controllers
{
    [Route("contactforms")]
    public class ContactFormController : Controller
    {
        IContactFormService _contactFormsService;

        public ContactFormController(IContactFormService contactFormsService)
        {
            _contactFormsService = contactFormsService;
        }


        [HttpGet("list")]
        public async Task<IActionResult> FormsList(int count = 10, int page = 1)
        {
            page = page <= 0 ? 1 : page;
            count = count > 25 ? 15 : count;

            List<ContactForm> list = await _contactFormsService.GetFormsListAsync(count, page);
            var p = await _contactFormsService.GetPagination(count, page);

            ViewBag.P = p;

            return View(list);
        }
    }
}
