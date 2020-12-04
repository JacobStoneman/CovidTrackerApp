using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidTrackerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CovidTrackerApp.Interfaces
{
	public interface IPatientService
	{
		Task<List<Patient>> RetrievePatientListAsync();
		Task<Patient> RetrievePatientById(int? id);
		DbSet<Venue> RetrieveVenues();
		Task AddPatientAsync(Patient patient);
		Task UpdatePatientAsync(Patient patient);
		Task RemovePatientAsync(Patient patient);
		bool PatientExists(int id);
	}
}
