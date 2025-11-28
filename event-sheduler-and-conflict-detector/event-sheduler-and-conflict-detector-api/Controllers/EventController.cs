using event_sheduler_and_conflict_detector_api.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace event_sheduler_and_conflict_detector_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private object _Context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPut]
        [Route("{}")]
        public async Task<ActionResult<List<Event>>> AddEvent(Event addevent)
        {
            var Title = addevent.Title;
            var Description = addevent.Description;
            var StartTime = addevent.StartTime;
            var EndTime = addevent.EndTime;
            var Location = addevent.Location;
            var Attendees = addevent.Attendees;
            var EventType = addevent.EventType;

            await _context.SaveChangesAsync();

            return Ok(_context.Events.ToListAsync());
        }
        [HttpGet]

        public async Task<ActionResult<List<Event>> GetAllEvent(Event allEvent)
        {
            var allEvent = await _context.Event.ToListAsync();
            if (allEvent == null)

                return Ok(allEvent);
        }
    }
}

