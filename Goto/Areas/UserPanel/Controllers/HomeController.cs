using Microsoft.AspNetCore.Mvc;

namespace Goto.Areas.UserPanel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
