using Microsoft.AspNetCore.Mvc;

namespace Goto.Areas.AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
