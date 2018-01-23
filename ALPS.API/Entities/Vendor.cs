using ALPS.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALPS.API.Entities
{
	[Table("Vendors")]
	public class Vendor : Company
	{
		public VendorType VendorType { get; set; }

		// Navigation properties
		public long SubscriberId { get; set; }
		public virtual Subscriber Subscriber { get; set; }
	}
}