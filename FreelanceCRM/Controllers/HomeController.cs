using FreelanceCRM.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FreelanceCRM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalLeads = _context.Leads.Count();
            ViewBag.TotalContacts = _context.Contacts.Count();
            ViewBag.TotalSales = _context.SalesReports.Sum(s => s.Amount);

            return View();
        }
    }
}
