using CovidTrackerApp.Data;
using CovidTrackerApp.Interfaces;
using CovidTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTrackerApp.Services
{
	public class CareWorkerService : ICareWorkerService
	{
		public readonly CovidTrackerAppContext db;
		public CareWorkerService(CovidTrackerAppContext context)
		{
			db = context;
		}

		public bool CareWorkerExists(int id) => db.CareWorker.Any(c => c.CareWorkerId == id);

		public async Task<CareWorker> FindAsync(int? id) => await db.CareWorker.FindAsync(id);

		public async Task<CareWorker> GetCareWorkerByIdAsync(int? id) => await db.CareWorker.Include(c => c.Venue).FirstOrDefaultAsync(c => c.CareWorkerId == id);

		public void RemoveCareWorker(CareWorker c) => db.CareWorker.Remove(c);

		public async Task SaveChangesAsync() => await db.SaveChangesAsync();

		public IEnumerable<Venue> GetVenues() => db.Venue;

		public void UpdateCareWorker(CareWorker c) => db.Update(c);

		public void AddCareWorker(CareWorker c) => db.Add(c);

		public IIncludableQueryable<CareWorker, Venue> GetCareworkers() => db.CareWorker.Include(c => c.Venue);
	}
}
