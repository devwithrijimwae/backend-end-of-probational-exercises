using event_sheduler_and_conflict_detector_api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace event_sheduler_and_conflict_detector_api
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }
    }
}
