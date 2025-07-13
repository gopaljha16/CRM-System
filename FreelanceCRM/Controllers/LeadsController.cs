using FreelanceCRM.Data;
using FreelanceCRM.Models;
using FreelanceCRM.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FreelanceCRM.Controllers
{
  

    public class LeadsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly EmailService _emailService;

        public LeadsController(ApplicationDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        // GET: Leads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Leads.ToListAsync());
        }

        // GET: Leads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var lead = await _context.Leads.FirstOrDefaultAsync(m => m.Id == id);
            if (lead == null)
                return NotFound();

            return View(lead);
        }

        // GET: Leads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leads/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Phone,Status,CreatedAt")] Lead lead)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lead);
                await _context.SaveChangesAsync();

                _emailService.SendEmail(
        lead.Email,
        "Thank You for Connecting with FreelanceCRM",
        $@"
    <html>
        <body style='font-family: Arial, sans-serif;'>
            <h2 style='color: #4CAF50;'>Hi {lead.Name},</h2>
            <p>Thank you for sharing your details with us. Our team has received your lead information and will get back to you shortly.</p>

            <h4>Lead Summary:</h4>
            <ul>
                <li><strong>Name:</strong> {lead.Name}</li>
                <li><strong>Email:</strong> {lead.Email}</li>
                <li><strong>Phone:</strong> {lead.Phone}</li>
                <li><strong>Status:</strong> {lead.Status}</li>
            </ul>

            <p>Feel free to reply to this email if you have any questions.</p>
            <p>Regards,<br/>FreelanceCRM Team</p>
        </body>
    </html>"
    );

                return RedirectToAction(nameof(Index));
            }
            return View(lead);
        }

        // GET: Leads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var lead = await _context.Leads.FindAsync(id);
            if (lead == null)
                return NotFound();

            return View(lead);
        }

        // POST: Leads/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Phone,Status,CreatedAt")] Lead lead)
        {
            if (id != lead.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lead);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeadExists(lead.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(lead);
        }

        // GET: Leads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var lead = await _context.Leads.FirstOrDefaultAsync(m => m.Id == id);
            if (lead == null)
                return NotFound();

            return View(lead);
        }

        public IActionResult TestEmail()
        {
            try
            {
                _emailService.SendEmail("your-email@gmail.com", "Test Email", "This is a test email from CRM app.");
                return Content("Email sent successfully.");
            }
            catch (Exception ex)
            {
                return Content("Error: " + ex.ToString());
            }
        }

        // POST: Leads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lead = await _context.Leads.FindAsync(id);
            if (lead != null)
            {
                _context.Leads.Remove(lead);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool LeadExists(int id)
        {
            return _context.Leads.Any(e => e.Id == id);
        }
    }
}
