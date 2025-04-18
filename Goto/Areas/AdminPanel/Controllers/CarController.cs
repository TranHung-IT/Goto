using Microsoft.AspNetCore.Mvc;

namespace Goto.Areas.AdminPanel.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
