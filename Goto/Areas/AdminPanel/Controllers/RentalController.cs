using Goto.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Goto.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Route("AdminPanel/Home")]
    [Authorize(Roles = "Admin")]
    public class RentalController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RentalController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var rentals = await _context.Rentals.Include(r => r.Car).Include(r => r.User).ToListAsync();
            return View(rentals);
        }

        public async Task<IActionResult> Approve(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null) return NotFound();
            rental.Status = "Approved";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
