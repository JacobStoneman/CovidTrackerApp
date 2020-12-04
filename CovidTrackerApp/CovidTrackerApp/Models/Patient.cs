using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTrackerApp.Models
{
	public class Patient
	{
		public int PatientId { get; set; }
		public string Name { get; set; }
		public DateTime DateOfDiagnosis { get; set; }
		public string NextOfKinName { get; set; }
		public string NextOfKinNumber { get; set; }
		public bool CheckedIn { get; set; }
		public bool Deceased { get; set; }
		public DateTime DOB { get; set; }
		public string Address { get; set; }
		public string ContactNumber { get; set; }
		public Venue Venue { get; set; }
		public int VenueId { get; set; }
	}
}
