using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CovidTrackerApp.Data;
using CovidTrackerApp.Models;

namespace CovidTrackerApp.Controllers
{
    public class CareWorkersController : Controller
    {
        private readonly CovidTrackerAppContext _context;

        public CareWorkersController(CovidTrackerAppContext context)
        {
            _context = context;
        }

        // GET: CareWorkers
        public async Task<IActionResult> Index()
        {
            var covidTrackerAppContext = _context.CareWorker.Include(c => c.Venue);
            return View(await covidTrackerAppContext.ToListAsync());
        }

        // GET: CareWorkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careWorker = await _context.CareWorker
                .Include(c => c.Venue)
                .FirstOrDefaultAsync(m => m.CareWorkerId == id);
            if (careWorker == null)
            {
                return NotFound();
            }

            return View(careWorker);
        }

        // GET: CareWorkers/Create
        public IActionResult Create()
        {
            ViewData["VenueId"] = new SelectList(_context.Venue, "VenueId", "VenueId");
            return View();
        }

        // POST: CareWorkers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CareWorkerId,Name,JobTitle,DOB,Address,ContactNumber,VenueId")] CareWorker careWorker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(careWorker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VenueId"] = new SelectList(_context.Venue, "VenueId", "VenueId", careWorker.VenueId);
            return View(careWorker);
        }

        // GET: CareWorkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careWorker = await _context.CareWorker.FindAsync(id);
            if (careWorker == null)
            {
                return NotFound();
            }
            ViewData["VenueId"] = new SelectList(_context.Venue, "VenueId", "VenueId", careWorker.VenueId);
            return View(careWorker);
        }

        // POST: CareWorkers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CareWorkerId,Name,JobTitle,DOB,Address,ContactNumber,VenueId")] CareWorker careWorker)
        {
            if (id != careWorker.CareWorkerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(careWorker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareWorkerExists(careWorker.CareWorkerId))
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
            ViewData["VenueId"] = new SelectList(_context.Venue, "VenueId", "VenueId", careWorker.VenueId);
            return View(careWorker);
        }

        // GET: CareWorkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careWorker = await _context.CareWorker
                .Include(c => c.Venue)
                .FirstOrDefaultAsync(m => m.CareWorkerId == id);
            if (careWorker == null)
            {
                return NotFound();
            }

            return View(careWorker);
        }

        // POST: CareWorkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var careWorker = await _context.CareWorker.FindAsync(id);
            _context.CareWorker.Remove(careWorker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareWorkerExists(int id)
        {
            return _context.CareWorker.Any(e => e.CareWorkerId == id);
        }
    }
}
