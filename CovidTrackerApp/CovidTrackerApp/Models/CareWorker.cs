using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTrackerApp.Models
{
	public class CareWorker : Person
	{
		public int CareWorkerId { get; set; }
		public string JobTitle { get; set; }
	}
}
