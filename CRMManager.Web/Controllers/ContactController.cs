using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRMManager.Web.Services.Interface;
using CRMManager.Web.Infrastructure;
using CRMManager.Contracts.Contacts;

namespace CRMManager.Web.Controllers
{
    [Route("contacts")]
    public class ContactController : Controller
    {
        IContactsService _contactsService;

        public ContactController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> ContactsList(int count = 10, int page = 1)
        {
            page = page <= 0 ? 1 : page;
            count = count > 25 ? 15 : count;

            var contacts = await _contactsService.GetContactsListAsync(count, page);
            var p = await _contactsService.GetPagination(count, page);

            ViewBag.P = p;
            return View(contacts);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> EditContact([FromRoute] Guid id) 
        {
            Contact contactDetails = await _contactsService.GetContactAsync(id);
            return View(contactDetails);
        }

        [HttpPut]
        [Route("edit/{id}")]
        public async Task EditContact([FromRoute]Guid id, [FromBody]EditableContact contact) 
        {
            await _contactsService.EditContact(id, contact);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task DeleteContact([FromRoute] Guid id)
        {
            await _contactsService.DeleteContact(id);
        }
    }
}
