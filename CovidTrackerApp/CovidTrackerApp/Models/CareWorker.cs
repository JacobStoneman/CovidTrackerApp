using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTrackerApp.Models
{
	public class CareWorker
	{
		public int CareWorkerId { get; set; }
		public string Name { get; set; }
		public string JobTitle { get; set; }
		public DateTime DOB { get; set; }
		public string Address { get; set; }
		public string ContactNumber { get; set; }
		public Venue Venue { get; set; }
		public int VenueId { get; set; }
	}
}
