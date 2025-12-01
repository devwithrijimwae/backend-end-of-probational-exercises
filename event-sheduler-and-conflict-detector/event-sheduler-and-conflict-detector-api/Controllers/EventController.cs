using System.Security.Claims;
using event_sheduler_and_conflict_detector_api.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace event_sheduler_and_conflict_detector_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        [HttpPost]
        public async Task<ActionResult<Event>> CreateEventWithConflictCheck([FromBody] Event newEvent)
        {
            if (newEvent == null)
                return BadRequest("Event data is required.");

            var conflictingEvents = await _context.Events
                .Where(e =>
                    newEvent.StartTime < e.EndTime &&
                    newEvent.EndTime > e.StartTime)
                .ToListAsync();

            if (conflictingEvents.Count != 0)
            {
                return Conflict(new
                {
                    message = "Event date conflicts with an existing event.",
                    conflicts = conflictingEvents.Select(e => new
                    {
                        e.Id,
                        e.Title,
                        e.StartTime,
                        e.EndTime
                    })
                });
            }

            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();

            return Ok(newEvent);
        }

        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetAllEventAsync()
        {
            var events = await _context.Events.ToListAsync();

            return Ok(events);
        }

        [HttpGet]
       [ Route("{id:int}")]
        public async Task<ActionResult<Event>> GetEventByIdAsync(int id)
        {
            var singleEvent = await _context.Events.FindAsync(id);
            if (singleEvent == null)
                return NotFound("Event not found.");

            return Ok(singleEvent);
        }

        [HttpPost]
        public async Task<ActionResult<List<Event>>> AddEventAsync(Event events)
        {
            await _context.Events.AddAsync(events);
            await _context.SaveChangesAsync();

            return Ok(await _context.Events.ToListAsync());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Event>>> UpdateEventAsync(int id, Event updatedEvent)
        {
            var existing = await _context.Events.FindAsync(id);
            if (existing == null)
                return NotFound("Event not found.");

            existing.Title = updatedEvent.Title;
            existing.Description = updatedEvent.Description;
            existing.StartTime = updatedEvent.StartTime;
            existing.EndTime = updatedEvent.EndTime;

            await _context.SaveChangesAsync();

            return Ok(await _context.Events.ToListAsync());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Event>>> DeleteEventAsync(int id)
        {
            var eventToDelete = await _context.Events.FindAsync(id);
            if (eventToDelete == null)
                return NotFound("Event not found.");

            _context.Events.Remove(eventToDelete);
            await _context.SaveChangesAsync();

            return Ok(await _context.Events.ToListAsync());
        }
    }
}
