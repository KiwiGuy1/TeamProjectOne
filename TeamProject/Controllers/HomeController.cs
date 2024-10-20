//JF should be good?

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamProject.Models;

namespace TeamProject.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext context { get; set; }

        public HomeController(ContactContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var contacts = context.Contacts.Include(m => m.Category).OrderBy(m => m.FirstName).ToList();
            return View(contacts);
        }

        public IActionResult Add()
        {
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
            return View(new Contact());
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
            var contact = context.Contacts.Find(id);

            return View(contact);
        }
    }
}
