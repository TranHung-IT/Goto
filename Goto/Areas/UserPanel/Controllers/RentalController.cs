using Goto.Data;
using Goto.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace Goto.Areas.UserPanel.Controllers
{
    [Area("User")]
    [Authorize]
    public class RentalController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RentalController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Book(int carId)
        {
            var car = _context.Cars.Find(carId);
            if (car == null) return NotFound();
            var model = new Rental { CarId = carId, Car = car };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Book(Rental rental)
        {
            if (ModelState.IsValid)
            {
                rental.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                rental.Status = "Pending";
                rental.Car = _context.Cars.Find(rental.CarId); // Load lại để đảm bảo không null

                if (rental.Car == null)
                {
                    ModelState.AddModelError("", "Không tìm thấy xe.");
                    return View(rental);
                }

                rental.TotalPrice = rental.Car.Price * (rental.EndDate - rental.StartDate).Days;
                _context.Add(rental);
                await _context.SaveChangesAsync();
                return RedirectToAction("Payment", new { rentalId = rental.Id });
            }

            rental.Car = _context.Cars.Find(rental.CarId);
            return View(rental);
        }

        [HttpPost]
        public async Task<IActionResult> Payment(int rentalId, string stripeToken)
        {
            var rental = await _context.Rentals.FindAsync(rentalId);
            if (rental == null)
            {
                return NotFound();
            }

            var options = new ChargeCreateOptions
            {
                Amount = (long)(rental.TotalPrice * 100),
                Currency = "usd",
                Source = stripeToken,
                Description = $"Rental {rentalId}"
            };

            var service = new ChargeService();
            var charge = await service.CreateAsync(options);

            if (charge.Status == "succeeded")
            {
                rental.Status = "Paid";
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View("Error");
        }
    }
}
