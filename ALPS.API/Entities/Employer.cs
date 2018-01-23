using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALPS.API.Entities
{
	[Table("Employers")]
	public class Employer : Company
    {
		public string EmploymentType { get; set; }
		
		// Navigation properties
		public long SubscriberId { get; set; }
		public virtual Subscriber Subscriber { get; set; }

		public virtual ICollection<Contact> Contacts { get; set; }
	}
}
