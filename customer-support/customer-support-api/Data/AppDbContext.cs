using System;
using System.Threading.Tasks;
using customer_support_api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace customer_support_api.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions <AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Ticket> Tickets { get; set; }

        internal async Task DeleteticketAsyc(Ticket updatedticket)
        {
            throw new NotImplementedException();
        }
    }
}
