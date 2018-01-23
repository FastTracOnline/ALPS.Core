using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ALPS.Common;
using ALPS.API.Interfaces;
using System.Collections.Generic;

namespace ALPS.API.Entities
{
	[Table("Agents")]
	public class Agent : People
	{
        public AgentType AgentType { get; set; }
		[DataType(DataType.Currency)]
		public decimal VolRepoPaid { get; set; }
		[DataType(DataType.Currency)]
		public decimal InvolRepoPaid { get; set; }
		[DataType(DataType.Currency)]
		public decimal TracePaid { get; set; }

		// Navigation properties
		public long SubscriberId { get; set; }
		public virtual Subscriber Subscriber { get; set; }

		public virtual ICollection<Order> Orders { get; set; }
	}
}