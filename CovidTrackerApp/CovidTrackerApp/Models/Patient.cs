using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTrackerApp.Models
{
	public class Patient : Person
	{
		public int PatientId { get; set; }
		public DateTime DateOfDiagnosis { get; set; }
		public string NextOfKinName { get; set; }
		public string NextOfKinNumber { get; set; }
		public bool CheckedIn { get; set; }
		public bool Deceased { get; set; }
	}
}
