using System;

namespace customer_support_api.Models.Entities
{
    public class Ticket
    {
        public int Id { get; set; } 
        public required string Subject { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public required string Status { get; set; }
    }
}
