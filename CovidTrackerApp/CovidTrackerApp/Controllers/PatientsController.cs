using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CovidTrackerApp.Data;
using CovidTrackerApp.Models;
using CovidTrackerApp.Services;
using CovidTrackerApp.Interfaces;


namespace CovidTrackerApp.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientService _service;

        public PatientsController(IPatientService service)
        {
            _service = service;
        }

        // GET: Patients
        public async Task<IActionResult> Index()
        {
            return View(await _service.RetrievePatientListAsync());
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _service.RetrievePatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            ViewData["VenueId"] = new SelectList(_service.RetrieveVenues(), "VenueId", "VenueId");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientId,Name,DateOfDiagnosis,NextOfKinName,NextOfKinNumber,CheckedIn,Deceased,DOB,Address,ContactNumber,VenueId")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                await _service.AddPatientAsync(patient);
                return RedirectToAction(nameof(Index));
            }
            ViewData["VenueId"] = new SelectList(_service.RetrieveVenues(), "VenueId", "VenueId", patient.VenueId);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _service.RetrievePatientById(id);
            if (patient == null)
            {
                return NotFound();
            }
            ViewData["VenueId"] = new SelectList(_service.RetrieveVenues(), "VenueId", "VenueId", patient.VenueId);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientId,Name,DateOfDiagnosis,NextOfKinName,NextOfKinNumber,CheckedIn,Deceased,DOB,Address,ContactNumber,VenueId")] Patient patient)
        {
            if (id != patient.PatientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdatePatientAsync(patient);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.PatientId))
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
            ViewData["VenueId"] = new SelectList(_service.RetrieveVenues(), "VenueId", "VenueId", patient.VenueId);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _service.RetrievePatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _service.RetrievePatientById(id);
            await _service.RemovePatientAsync(patient);
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
            return _service.PatientExists(id);
        }
    }
}
