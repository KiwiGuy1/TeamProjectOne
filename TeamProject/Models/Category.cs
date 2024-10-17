using Microsoft.AspNetCore.Mvc;

namespace TeamProject.Models
{
    public class Category : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
