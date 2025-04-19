﻿using Microsoft.AspNetCore.Identity;

namespace Goto.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Status { get; set; }
        public Car? Car { get; set; }
        public IdentityUser? User { get; set; }
    }
}
