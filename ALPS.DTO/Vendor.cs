using ALPS.Common;

namespace ALPS.DTO
{
	public class Vendor : Company
	{
		public VendorType VendorType { get; set; }

		// Navigation properties
		public long SubscriberId { get; set; }
		public virtual Subscriber Subscriber { get; set; }
	}
}