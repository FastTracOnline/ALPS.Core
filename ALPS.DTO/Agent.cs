using System;
using ALPS.Common;

namespace ALPS.DTO
{
	public class Agent : People
	{
        public AgentType AgentType { get; set; }
		public decimal VolRepoPaid { get; set; }
		public decimal InvolRepoPaid { get; set; }
		public decimal TracePaid { get; set; }

		// Navigation properties
		public long SubscriberId { get; set; }
		public virtual Subscriber Subscriber { get; set; }
	}
}