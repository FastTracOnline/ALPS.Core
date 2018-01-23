using ALPS.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALPS.MVC.ViewModels
{
	public class Contact : People
    {
		public Contact()
		{
			Employer = new Employer();
		}

		[Display(Name = "Relation to Debtor")]
		public RelationshipType RelationToDebtor { get; set; }
		[Display(Name = "SSN")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###-##-####}")]
		public string SSN { get; set; }
		[Display(Name = "DL Number")]
		public string LicenseNumber { get; set; }
		[Display(Name = "DL State")]
		[MaxLength(2)]
		public string LicenseState { get; set; }

		// Navigation properties
		public long SubscriberId { get; set; }
		public virtual Subscriber Subscriber { get; set; }

		public long? EmployerId { get; set; }
		public virtual Employer Employer { get; set; }

		public long OrderId { get; set; }
		public virtual Order Order { get; set; }
	}
}
