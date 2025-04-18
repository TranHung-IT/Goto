using Microsoft.AspNetCore.Mvc;

namespace Goto.Areas.AdminPanel.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
