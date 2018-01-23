namespace ALPS.DTO
{
	public class PoliceDepartment : Company
	{
		// Navigation properties
		public long SubscriberId { get; set; }
		public virtual Subscriber Subscriber { get; set; }
	}
}