using ALPS.API.Interfaces;
using ALPS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALPS.API.Entities
{
	public class MakeModel : IVersionedEntity
    {
		public MakeModel()
		{
			Vehicles = new List<Vehicle>();
		}

		[Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		public Manufacturer Manufacturer { get; set; }
		public Model Model { get; set; }
		public string Notes { get; set; }
		public string Tips { get; set; }
		public bool Active { get; set; }
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }

		[Timestamp]
		public byte[] Version { get; set; }

		// Navigation properties
		public long SubscriberId { get; set; }
		public virtual Subscriber Subscriber { get; set; }

		public virtual ICollection<Vehicle> Vehicles { get; set; }
	}
}
