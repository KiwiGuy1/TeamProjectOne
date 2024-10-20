//JF Might be ok now?

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TeamProject.Models;

namespace TeamProject.Controllers
{
    public class ContactController : Controller
    {

        private ContactContext context { get; set; }



        public ContactController(ContactContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var contacts = context.Contacts.Include(c => c.Category).ToList();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.Name }).ToList();
            return View(new Contact());
        }

        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.DateAdded = DateTime.Now;

                context.Contacts.Add(contact);
                context.SaveChanges();

                return RedirectToAction("Index", "");
            }

            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.Name }).ToList();
            return View(new Contact());
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var contact = context.Contacts.Include(c => c.Category).FirstOrDefault(c => c.ContactId == id);
            return View(contact);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            // Fetch the contact to be edited
            var contact = context.Contacts.Include(c => c.Category).FirstOrDefault(c => c.ContactId == id);

            if (contact == null)
            {
                return NotFound();
            }

            // Set the categories for the dropdown
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name)
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.Name
                }).ToList();

            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                context.Contacts.Update(contact);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            // Repopulate ViewBag.Categories for the view in case of validation failure
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name)
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.Name
                }).ToList();

            return View(contact);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        // Fetch the contact to confirm deletion
        {
            var contact = context.Contacts.Find(id);
            if (contact == null) return NotFound();
            return View(contact);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            Console.WriteLine($"Attempting to delete contact with ID: {id}");
            var contact = context.Contacts.Find(id);
            if (contact != null)
            {
                context.Contacts.Remove(contact);
                context.SaveChanges();
                Console.WriteLine("Contact deleted successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
            return RedirectToAction("Index", "Home");
        }




    }

}