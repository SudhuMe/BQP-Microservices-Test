using Microsoft.EntityFrameworkCore;
using Persistance.Entities;
using Infrastructure.Perception;
using Infrastructure.Services;

namespace BookingService.Persistance
{
    public class BookingDbContext : BaseDbContext
    {
        public BookingDbContext(DbContextOptions options, ICurrentUserService currentUserService) : base(options, currentUserService)
        {
        }

        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
            .Property(u => u.PaymentStatus)
            .HasConversion<string>()
            .HasMaxLength(50);
        }

    }
}


