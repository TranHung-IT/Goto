using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Goto.Areas.AdminPanel.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
