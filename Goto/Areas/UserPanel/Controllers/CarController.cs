using Microsoft.AspNetCore.Mvc;

namespace Goto.Areas.UserPanel.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
