using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALPS.MVC.ViewModels
{
	public class Lienholder : Company
	{
		public int PropertyDaysFree { get; set; }
		public decimal PropertyInitialFee { get; set; }
		public decimal PropertyDailyFee { get; set; }
		public int VehicleDaysFree { get; set; }
		public decimal VehicleInitialFee { get; set; }
		public decimal VehicleDailyFee { get; set; }

		// Navigation properties
		public long SubscriberId { get; set; }
		public virtual Subscriber Subscriber { get; set; }

		public virtual ICollection<Order> Orders { get; set; }
	}
}
