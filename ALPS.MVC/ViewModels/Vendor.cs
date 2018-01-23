using ALPS.Common;

namespace ALPS.MVC.ViewModels
{
	public class Vendor : Company
	{
		public VendorType VendorType { get; set; }

		// Navigation properties
		public long SubscriberId { get; set; }
		public virtual Subscriber Subscriber { get; set; }
	}
}