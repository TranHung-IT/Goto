using Microsoft.AspNetCore.Mvc;

namespace Goto.Areas.UserPanel.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
