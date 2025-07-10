using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FreelanceCRM.Data;
using FreelanceCRM.Models;

namespace FreelanceCRM.Controllers
{
    public class SalesReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalesReports
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesReports.ToListAsync());
        }

        // GET: SalesReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesReport = await _context.SalesReports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesReport == null)
            {
                return NotFound();
            }

            return View(salesReport);
        }

        // GET: SalesReports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Amount,Date")] SalesReport salesReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesReport);
        }

        // GET: SalesReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesReport = await _context.SalesReports.FindAsync(id);
            if (salesReport == null)
            {
                return NotFound();
            }
            return View(salesReport);
        }

        // POST: SalesReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Amount,Date")] SalesReport salesReport)
        {
            if (id != salesReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesReportExists(salesReport.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(salesReport);
        }

        // GET: SalesReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesReport = await _context.SalesReports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesReport == null)
            {
                return NotFound();
            }

            return View(salesReport);
        }

        // POST: SalesReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesReport = await _context.SalesReports.FindAsync(id);
            if (salesReport != null)
            {
                _context.SalesReports.Remove(salesReport);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesReportExists(int id)
        {
            return _context.SalesReports.Any(e => e.Id == id);
        }
    }
}
