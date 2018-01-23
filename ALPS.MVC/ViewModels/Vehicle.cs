using ALPS.Common;
using System;
using System.Collections.Generic;

namespace ALPS.MVC.ViewModels
{
	public class Vehicle
    {
		public long Id { get; set; }
		public string VIN { get; set; }
		public string VIN6 => VIN?.GetLast(6); 
		public VehicleType VehicleType { get; set; }
		public VehicleBodyType VehicleBodyType { get; set; }
		public int Cylinders { get; set; }
		public string Year { get; set; }
		public string Color { get; set; }
		public string Tag { get; set; }
		public string TagState { get; set; }
		public string IgnitionCode { get; set; }
		public string TrunkCode { get; set; }
		public string VATCode { get; set; }
		public bool? Insured { get; set; }

		public string Notes { get; set; }
		public bool Active { get; set; }
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }

		public byte[] Version { get; set; }

		// Navigation properties
		public long SubscriberId { get; set; }
		public virtual Subscriber Subscriber { get; set; }

		public long MakeModelId { get; set; }
		public virtual MakeModel MakeModel { get; set; }

		public virtual ICollection<Order> Orders { get; set; }
	}
}
