using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTrackerApp.Models
{
	public class Person
	{
		public int PersonId { get; set; }
		public DateTime DOB { get; set; }
		public string Address { get; set; }
		public string Contact { get; set; }
		public Venue Venue { get; set; }
	}
}
