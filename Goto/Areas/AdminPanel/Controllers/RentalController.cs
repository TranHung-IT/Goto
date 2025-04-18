using Microsoft.AspNetCore.Mvc;

namespace Goto.Areas.AdminPanel.Controllers
{
    public class RentalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
