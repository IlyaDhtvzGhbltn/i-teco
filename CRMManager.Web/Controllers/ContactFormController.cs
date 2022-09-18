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
        [HttpGet("list")]
        public IActionResult FormsList()
        {
            return View();
        }
    }
}
