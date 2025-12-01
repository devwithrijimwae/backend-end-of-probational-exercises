using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using customer_support_api.Data;
using customer_support_api.Models.Entities;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace customer_support_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TicketController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Ticket>>> GetAllTicket()
        {
            var Tickets = await _context.Tickets.FindAsync();

            return Ok(Tickets);
        }
        [HttpGet]
        [Route("{Id:int}")]
        public async Task<ActionResult<List<Ticket>>> GetTicket(int Id)
        {
            var Ticket = await _context.Tickets.FindAsync(Id);
            if (Ticket == null)
                return NotFound();
            return Ok(Ticket);
        }
        [HttpPost]
        public async Task<ActionResult<List<Ticket>>> AddTicketAsync(Ticket ticket)
        {
            await _context.AddAsync(ticket);
            _context.SaveChanges();


            return Ok(await _context.Tickets.ToListAsync());
        }
        [HttpPut]
        [Route("{Id:int}")]
        public async Task<ActionResult<List<Ticket>>> UpdateTicketAsync(int Id, [FromBody] Ticket updateticket)
        {
            var Ticket = await _context.Tickets.FindAsync(Id);
            if (Ticket == null)
                return NotFound();

            updateticket.Subject = updateticket.Subject;
            updateticket.Description = updateticket.Description;
            updateticket.CreatedAt = updateticket.CreatedAt;


            await _context.DeleteticketAsyc(updateticket);
            _context.SaveChanges();


            return Ok(await _context.Tickets.ToListAsync());
        }
        [HttpDelete]
        public async Task<ActionResult<List<Ticket>>> DeleteTicketAsync(int Id, [FromBody] Ticket deleteticket)
        {
            var Ticket = await _context.Tickets.FindAsync(Id);


            await _context.DeleteticketAsyc(deleteticket);
            _context.SaveChanges();


            return Ok(await _context.Tickets.FindAsync());
        }
    }
}
