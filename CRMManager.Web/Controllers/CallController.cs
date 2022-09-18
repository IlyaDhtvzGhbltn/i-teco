using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMManager.Web.Controllers
{
    [Route("calls")]
    public class CallController : Controller
    {
        [HttpGet("list")]
        public IActionResult CallsList()
        {
            return View();
        }
    }
}
