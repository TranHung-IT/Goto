﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Goto.Areas.UserPanel.Controllers
{
    [Area("User")]
    [Authorize]
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
