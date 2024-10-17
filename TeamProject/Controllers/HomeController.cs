using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
//JF should be good?

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamProject.Models;

namespace TeamProject.Controllers
{
    public class HomeController : Controller
    {
        private ManagerContext context { get; set; }

        public HomeController(ManagerContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var managers = context.Managers.Include(m => m.Category).OrderBy(m => m.FirstName).ToList();
            return View(managers);
        }
    }
}
