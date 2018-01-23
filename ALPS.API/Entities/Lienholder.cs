using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ALPS.API.Entities
{
	[Table("Lienholders")]
    public class Lienholder : Company
    {
        public int PropertyDaysFree { get; set; }
        [DataType(DataType.Currency)]
        public decimal PropertyInitialFee { get; set; }
        [DataType(DataType.Currency)]
        public decimal PropertyDailyFee { get; set; }
        public int VehicleDaysFree { get; set; }
        [DataType(DataType.Currency)]
        public decimal VehicleInitialFee { get; set; }
        [DataType(DataType.Currency)]
        public decimal VehicleDailyFee { get; set; }

		// Navigation Properties
		public long SubscriberId { get; set; }
		public virtual Subscriber Subscriber { get; set; }

		public virtual ICollection<Order> Orders { get; set; }
    }
}
