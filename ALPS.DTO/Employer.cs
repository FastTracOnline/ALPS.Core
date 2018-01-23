using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALPS.DTO
{
	public class Employer : Company
    {
		public string EmploymentType { get; set; }
		
		// Navigation properties
		public long SubscriberId { get; set; }
		public virtual Subscriber Subscriber { get; set; }
	}
}
