using System.ComponentModel.DataAnnotations.Schema;

namespace ALPS.API.Entities
{
	[Table("PoliceDepartments")]
	public class PoliceDepartment : Company
	{
		// Navigation properties
		public long SubscriberId { get; set; }
		public virtual Subscriber Subscriber { get; set; }
	}
}