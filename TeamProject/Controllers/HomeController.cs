using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
//JF Looks grumnpy now but hopefully should fix as we go

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
            //JF Category and Name will probably need some work
            var movies = context.Manager.Include(m => m.Category).OrderBy(m => m.Name).ToList();
            return View(manager);
        }
    }
}
