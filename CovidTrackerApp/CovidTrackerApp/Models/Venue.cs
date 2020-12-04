using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTrackerApp.Models
{
	public class Venue
	{
		public int VenueId { get; set; }
		[Required]
		[Display(Name = "Name")]
		[RegularExpression(@"^[A-Z]+[a-zA-Z' ']*$")]
		public string VenueName { get; set; }
		[Required]
		[RegularExpression(@"^[0-9]|[A-Z]|[a-z' ',]*$")]
		public string Address { get; set; }
		public int Capacity { get; set; }
		public int NumOfPatients { get; set; }
		public int NumOfWorkers { get; set; }
		public List<Patient> Patients { get; set; }
		public List<CareWorker> CareWorkers { get; set; }
	}
}
