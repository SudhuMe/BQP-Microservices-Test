using AutoMapper;
using ContentService.CQRS.Commands.CreateBooking.Request;
using ContentService.CQRS.Commands.CreateBooking;
using Service.Shared;
using CQRS.Commands.CreateBooking;

namespace ContentService.AutoMapper
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<CreateBookingRequest, CreateBookingCommand>();
            CreateMap<CreateBookingRequest, BookingCreatedEvent>();
        }
    }
}
