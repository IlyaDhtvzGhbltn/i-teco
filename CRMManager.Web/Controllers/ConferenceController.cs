using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMManager.Web.Controllers
{
    [Route("conferences")]
    public class ConferenceController : Controller
    {
        [HttpGet("list")]
        public IActionResult ConferencesList()
        {
            return View();
        }
    }
}
