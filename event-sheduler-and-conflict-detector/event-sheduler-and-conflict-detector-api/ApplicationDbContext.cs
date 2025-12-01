using event_sheduler_and_conflict_detector_api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace event_sheduler_and_conflict_detector_api
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Event> Events { get; set; }

        internal void AddEventAsync(Event events)
        {
            throw new NotImplementedException();
        }

        internal void RemoveAsync()
        {
            throw new NotImplementedException();
        }

        internal void UpdateEvent(Event updatedevents)
        {
            throw new NotImplementedException();
        }
    }
}
