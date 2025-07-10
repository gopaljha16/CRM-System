using Microsoft.EntityFrameworkCore;
using FreelanceCRM.Models;

namespace FreelanceCRM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Lead> Leads { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SalesReport> SalesReports { get; set; }
    }
}
