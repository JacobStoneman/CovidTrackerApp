using CovidTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace CovidTrackerApp.Interfaces
{
	public interface ICareWorkerService
	{
		bool CareWorkerExists(int id);
		Task SaveChangesAsync();
		Task<CareWorker> FindAsync(int? id);
		void RemoveCareWorker(CareWorker c);
		Task<CareWorker> GetCareWorkerByIdAsync(int? id);
		public IEnumerable<Venue> GetVenues();
		public void UpdateCareWorker(CareWorker c);
		public void AddCareWorker(CareWorker c);
		public IIncludableQueryable<CareWorker,Venue> GetCareworkers();
	}
}
