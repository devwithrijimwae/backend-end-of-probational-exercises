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
        public async Task<ActionResult<List<Ticket>>> GetTicket(int Id, Ticket ticket)
        {
            var Ticket = await _context.Tickets.FindAsync(Id);

            return Ok(Ticket);
        }
    }
}
