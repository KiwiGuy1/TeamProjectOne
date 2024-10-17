//JF Might be ok now?

using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TeamProject.Models;

namespace TeamProject.Controllers
{
    public class ManagerController : Controller
    {
        private ManagerContext context { get; set; }

        public ManagerController(ManagerContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
            return View("Edit", new Manager());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
            var manager = context.Managers.Find(id);
            return View(manager);
        }

        [HttpPost]
        public IActionResult Edit(Manager manager)
        {
            if (ModelState.IsValid)
            {
                if (manager.ManagerId == 0)
                    context.Managers.Add(manager);
                else
                    context.Managers.Update(manager);

                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (manager.ManagerId == 0) ? "Add" : "Edit";
                ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
                return View(manager);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var manager = context.Managers.Find(id);
            return View(manager);
        }

        [HttpPost]
        public IActionResult Delete(Manager manager)
        {
            context.Managers.Remove(manager);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}