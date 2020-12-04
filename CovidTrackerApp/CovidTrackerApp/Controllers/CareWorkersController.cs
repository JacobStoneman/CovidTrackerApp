using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CovidTrackerApp.Data;
using CovidTrackerApp.Models;
using CovidTrackerApp.Interfaces;

namespace CovidTrackerApp.Controllers
{
    public class CareWorkersController : Controller
    {
        private readonly ICareWorkerService _service;

        public CareWorkersController(ICareWorkerService service)
        {
            _service = service;
        }

        // GET: CareWorkers
        public async Task<IActionResult> Index()
        {
            var covidTrackerAppContext = _service.GetCareworkers();
            return View(await covidTrackerAppContext.ToListAsync());
        }

        // GET: CareWorkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careWorker = await _service.GetCareWorkerByIdAsync(id);
            if (careWorker == null)
            {
                return NotFound();
            }

            return View(careWorker);
        }

        // GET: CareWorkers/Create
        public IActionResult Create()
        {
            ViewData["VenueId"] = new SelectList(_service.GetVenues(), "VenueId", "VenueId");
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
                _service.AddCareWorker(careWorker);
                await _service.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VenueId"] = new SelectList(_service.GetVenues(), "VenueId", "VenueId", careWorker.VenueId);
            return View(careWorker);
        }

        // GET: CareWorkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careWorker = await _service.FindAsync(id);
            if (careWorker == null)
            {
                return NotFound();
            }
            ViewData["VenueId"] = new SelectList(_service.GetVenues(), "VenueId", "VenueId", careWorker.VenueId);
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
                    _service.UpdateCareWorker(careWorker);
                    await _service.SaveChangesAsync();
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
            ViewData["VenueId"] = new SelectList(_service.GetVenues(), "VenueId", "VenueId", careWorker.VenueId);
            return View(careWorker);
        }

        // GET: CareWorkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careWorker = await _service.GetCareWorkerByIdAsync(id);
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
            var careWorker = await _service.FindAsync(id);
            _service.RemoveCareWorker(careWorker);
            await _service.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareWorkerExists(int id) => _service.CareWorkerExists(id);
    }
}
