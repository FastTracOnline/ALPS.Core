using ALPS.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALPS.DTO
{
	public class Contact : People
    {
		public RelationshipType RelationToDebtor { get; set; }
		public string SSN { get; set; }
		public string LicenseNumber { get; set; }
		public string LicenseState { get; set; }

		// Navigation properties
		public long SubscriberId { get; set; }
		public virtual Subscriber Subscriber { get; set; }

		public long OrderId { get; set; }
		public virtual Order Order { get; set; }

		public long? EmployerId { get; set; }
		public virtual Employer Employer { get; set; }
	}
}
