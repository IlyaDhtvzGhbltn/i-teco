using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMManager.Web.Controllers
{
    [Route("phones")]
    public class PhoneController : Controller
    {
        [HttpGet("list")]
        public IActionResult PhonesList()
        {
            return View();
        }
    }
}
