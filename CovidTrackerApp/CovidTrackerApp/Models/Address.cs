using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTrackerApp.Models
{
	public class Address
	{
		public int HouseNumber { get; set; }
		public string Street { get; set; }
		public string City { get; set; }

		//TODO: Regex
		public string Postcode { get; set; }

		public string GetAddress() => $"{HouseNumber} {Street} {City} {Postcode}";
	}
}
