using Microsoft.AspNetCore.Mvc;

namespace Goto.Areas.UserPanel.Controllers
{
    public class RentalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
