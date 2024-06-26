﻿using UserService.CQRS.Queries.GetBooking.Response;
using Abstraction;
using Persistance.Repository;
using Persistance.Entities;

namespace UserService.CQRS.Queries.GetBooking;

public class GetBookingQuery() : IRequest<GetBookingQueryResponse>, ICachableQuery
{
    public int BookingId { get; set; }
    public bool BypassCache { get; set; }
    public string CacheKey => $"booking-{BookingId}";
    public TimeSpan? SlidingExpiration { get; set; }
}

internal class GetBookingQueryHandler(IBookingRepository _repository) : IRequestHandler<GetBookingQuery, GetBookingQueryResponse>
{
    public async Task<GetBookingQueryResponse> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        var booking =  await _repository.GetBookingAsync(request.BookingId);
        if ( booking is null)
            throw new NotFoundException(request.BookingId.ToString(), nameof(Booking));

        return new GetBookingQueryResponse(booking.Id , booking.RoomId, booking.BookingDate, booking.PaymentStatus.ToString());
    }
}