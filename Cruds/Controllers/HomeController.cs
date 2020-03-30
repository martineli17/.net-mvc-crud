using Microsoft.AspNetCore.Mvc;

namespace Apresentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}