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
            return View(await _context.CareWorker.ToListAsync());
        }

        // GET: CareWorkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careWorker = await _context.CareWorker
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (careWorker == null)
            {
                return NotFound();
            }

            return View(careWorker);
        }

        // GET: CareWorkers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CareWorkers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CareWorkerId,JobTitle,PersonId,DOB,Address,Contact")] CareWorker careWorker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(careWorker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(careWorker);
        }

        // POST: CareWorkers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CareWorkerId,JobTitle,PersonId,DOB,Address,Contact")] CareWorker careWorker)
        {
            if (id != careWorker.PersonId)
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
                    if (!CareWorkerExists(careWorker.PersonId))
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
                .FirstOrDefaultAsync(m => m.PersonId == id);
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
            return _context.CareWorker.Any(e => e.PersonId == id);
        }
    }
}
