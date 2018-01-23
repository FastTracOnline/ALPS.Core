using ALPS.Common;
using System.ComponentModel.DataAnnotations;

namespace ALPS.MVC.ViewModels
{
	public class Agent : People
	{
		[Display(Name ="Agent Type")]
		[EnumDataType(typeof(AgentType))]
		public AgentType AgentType { get; set; }
		[Display(Name = "Voluntary")]
		public decimal VolRepoPaid { get; set; }
		[Display(Name = "Invountary")]
		public decimal InvolRepoPaid { get; set; }
		[Display(Name = "Trace")]
		public decimal TracePaid { get; set; }

		// Navigation properties
		public long SubscriberId { get; set; }
		public virtual Subscriber Subscriber { get; set; }
	}
}