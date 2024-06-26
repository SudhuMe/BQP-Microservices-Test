﻿using Microsoft.EntityFrameworkCore;
using Persistance.Entities;
using ContentService.Persistance;

namespace Persistance.Repository;

public class BookingRepository(BookingDbContext _context) : IBookingRepository
{
    public async Task<Booking> GetBookingAsync(int bookingId)
    {
        return await _context.Bookings.FirstOrDefaultAsync(w => w.Id == bookingId);
    }

    public async Task<int> CreateBookingAsync(Booking booking)
    {
        _context.Bookings.Add(booking);

        await _context.SaveChangesAsync();

        return booking.Id;
    }

    public async Task UpdateBookingStatusAsync(Booking booking)
    {
        var existingBooking = await _context.Bookings.FindAsync(booking.Id);

        if (existingBooking != null)
        {
            existingBooking.PaymentStatus = booking.PaymentStatus;

            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Booking>> GetBookingsAsync()
    {
        return await _context.Bookings.ToListAsync();
    }
}
