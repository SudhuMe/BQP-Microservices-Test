using AutoMapper;
using UserService.CQRS.Commands.CreateBooking.Request;
using UserService.CQRS.Commands.CreateBooking;
using Service.Shared;
using CQRS.Commands.CreateBooking;

namespace UserService.AutoMapper
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
