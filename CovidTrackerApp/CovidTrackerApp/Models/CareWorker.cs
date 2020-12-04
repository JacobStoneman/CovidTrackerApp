using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTrackerApp.Models
{
	public class CareWorker
	{
		public int CareWorkerId { get; set; }
		[Required]
		[RegularExpression(@"^[A-Z]+[a-zA-Z' ']*$")]
		public string Name { get; set; }
		[Required]
		[Display(Name = "Job Title")]
		[RegularExpression(@"^[A-Z]+[a-zA-Z' ']*$")]
		public string JobTitle { get; set; }
		[Required]
		[Display(Name = "D.o.B")]
		public DateTime DOB { get; set; }
		[Required]
		[RegularExpression(@"^[0-9A-Za-z' ',]*$")]
		public string Address { get; set; }
		[Required]
		[Display(Name = "Contact Number")]
		[StringLength(11, MinimumLength = 7)]
		[RegularExpression(@"^[0-9]")]
		public string ContactNumber { get; set; }
		public Venue Venue { get; set; }
		public int VenueId { get; set; }
	}
}
