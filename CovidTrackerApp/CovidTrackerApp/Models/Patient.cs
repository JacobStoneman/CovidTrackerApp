using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTrackerApp.Models
{
	public class Patient
	{
		public int PatientId { get; set; }
		[Required]
		[RegularExpression(@"^[A-Z]+[a-zA-Z' ']*$")]
		public string Name { get; set; }
		[Required]
		[Display(Name = "Date of Diagnosis")]
		public DateTime DateOfDiagnosis { get; set; }
		[Required]
		[Display(Name = "Next of Kin Name")]
		[RegularExpression(@"^[A-Z]+[a-zA-Z' ']*$")]
		public string NextOfKinName { get; set; }
		[Required]
		[Display(Name = "Next of Kin Contact Number")]
		[StringLength(11, MinimumLength = 7)]
		[RegularExpression(@"^[0-9]")]
		public string NextOfKinNumber { get; set; }
		[Required]
		[Display(Name = "Checked In")]
		public bool CheckedIn { get; set; }
		[Required]
		[Display(Name = "Deceased")]
		public bool Deceased { get; set; }
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
		[Required]
		public Venue Venue { get; set; }
		public int VenueId { get; set; }
	}
}
