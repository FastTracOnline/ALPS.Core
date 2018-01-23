using ALPS.Common;
using System;
using System.Collections.Generic;

namespace ALPS.MVC.ViewModels
{
	public class MakeModel 
    {
		public MakeModel()
		{
			Vehicles = new List<Vehicle>();
		}

		public long Id { get; set; }
		public Manufacturer Manufacturer { get; set; }
		public Model Model { get; set; }
		public string Notes { get; set; }
		public string Tips { get; set; }
		public bool Active { get; set; }
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }

		public byte[] Version { get; set; }

		// Navigation properties
		public long SubscriberId { get; set; }
		public virtual Subscriber Subscriber { get; set; }

		public virtual ICollection<Vehicle> Vehicles { get; set; }
	}
}
