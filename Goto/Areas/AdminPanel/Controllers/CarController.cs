using Goto.Data;
using Goto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Goto.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Route("AdminPanel/Home")]
    [Authorize(Roles = "Admin")]
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CarController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await _context.Cars.ToListAsync();
            return View(cars);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Car car, IFormFile image, IFormFile model3D)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var fileName = Path.GetRandomFileName() + Path.GetExtension(image.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    car.ImageUrl = "/images/" + fileName;
                }
                if (model3D != null)
                {
                    var fileName = Path.GetRandomFileName() + Path.GetExtension(model3D.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/models", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model3D.CopyToAsync(stream);
                    }
                    car.Model3DUrl = "/models/" + fileName;
                }
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }
    }
}
