using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidTrackerApp.Interfaces;
using CovidTrackerApp.Data;
using CovidTrackerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CovidTrackerApp.Services
{
	public class PatientService : IPatientService
	{
		private readonly CovidTrackerAppContext _context;
		public PatientService(CovidTrackerAppContext context)
		{
			_context = context;
		}

		public async Task<List<Patient>> RetrievePatientListAsync()
		{ 
			return await _context.Patient.Include(p => p.Venue).ToListAsync();
		}
		public async Task<Patient> RetrievePatientById(int? id)
		{
			return await _context.Patient
				.Include(p => p.Venue)
				.FirstOrDefaultAsync(m => m.PatientId == id);
		}
		public DbSet<Venue> RetrieveVenues()
		{
			return _context.Venue;
		}
		public async Task AddPatientAsync(Patient patient)
		{
			_context.Add(patient);
			await _context.SaveChangesAsync();
		}
		public async Task UpdatePatientAsync(Patient patient)
		{
			_context.Update(patient);
			await _context.SaveChangesAsync();
		}
		public async Task RemovePatientAsync(Patient patient)
		{
			_context.Remove(patient);
			await _context.SaveChangesAsync();
		}
		public bool PatientExists(int id)
		{
			return _context.Patient.Any(e => e.PatientId == id);
		}
	}
}
