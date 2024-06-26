﻿using Abstraction.Result;

namespace BookingService;

public static class BookingErrors
{
    public static Error Unavailable(DateTime bookingDate) => new Error("Date.Unavailable", $"Booking is not available for {bookingDate}");
}
