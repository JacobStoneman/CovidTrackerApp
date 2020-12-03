﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTrackerApp.Models
{
	public class Venue
	{
		public int VenueId { get; set; }
		public string Address { get; set; }
		public int Capacity { get; set; }
		public int NumOfPatients { get; set; }
		public int WorkerNum { get; set; }
	}
}
