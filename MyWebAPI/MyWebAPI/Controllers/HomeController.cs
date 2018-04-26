using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}