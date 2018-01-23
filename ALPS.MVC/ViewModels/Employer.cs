using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALPS.MVC.ViewModels
{
	public class Employer : Company
    {
		[Display(Name = "Position")]
		public string EmploymentType { get; set; }
		
		// Navigation properties
		public long SubscriberId { get; set; }
		public virtual Subscriber Subscriber { get; set; }
	}
}
