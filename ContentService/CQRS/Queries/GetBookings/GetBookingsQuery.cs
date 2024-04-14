using MediatR;
using ContentService.CQRS.Queries.GetBookings.Response;
using Abstraction;
using Abstraction.Result;
using Persistance.Repository;

namespace ContentService.CQRS.Queries.GetBookings;

    public class GetBookingsQuery : IRequest<Result<List<GetBookingsQueryResponse>>>, ICachableQuery
    {
        public bool BypassCache { get; set; }
        public string CacheKey => $"booking-list";
        public TimeSpan? SlidingExpiration { get; set; }
    }

internal class GetBookingListQueryHandler(IBookingRepository _repository) : IRequestHandler<GetBookingsQuery, Result<List<GetBookingsQueryResponse>>>
{
    public async Task<Result<List<GetBookingsQueryResponse>>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
    {
        var bookings = await _repository.GetBookingsAsync();

        var getBookingQueryResponses = bookings.Select(booking => new GetBookingsQueryResponse
        {
            BookingId = booking.Id,
            RoomId = booking.RoomId,
            BookingDate = booking.BookingDate,
            PaymentStatus = booking.PaymentStatus.ToString()
        }).ToList();

        return Result<List<GetBookingsQueryResponse>>.Success(getBookingQueryResponses);
    }
}
