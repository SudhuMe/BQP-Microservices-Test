using Service.Shared.Enum;

namespace Service.Shared
{
    public class PaymentProcessedEvent
    {
        public int BookingId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
