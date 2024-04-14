using Abstraction.Result;

namespace ContentService;

public static class BookingErrors
{
    public static Error Unavailable(DateTime bookingDate) => new Error("Date.Unavailable", $"Booking is not available for {bookingDate}");
}
