using System;

namespace customer_support_api
{
    public class AddTicketDto
    {
        public required string Subject { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string Status { get; set; }
    }
}
