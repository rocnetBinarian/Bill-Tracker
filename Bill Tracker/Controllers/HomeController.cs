using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bill_Tracker.Models;
using Serilog;

namespace Bill_Tracker.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        public HomeController()
            : base(Log.ForContext<HomeController>())
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
