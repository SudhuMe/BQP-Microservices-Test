using AutoMapper;
using BookingService.CQRS.Commands.CreateBooking.Request;
using BookingService.CQRS.Commands.CreateBooking;
using Service.Shared;
using CQRS.Commands.CreateBooking;

namespace BookingService.AutoMapper
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
