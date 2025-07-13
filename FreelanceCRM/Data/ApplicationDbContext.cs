using FreelanceCRM.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FreelanceCRM.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Lead> Leads { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SalesReport> SalesReports { get; set; }
    }
}
