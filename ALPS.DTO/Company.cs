using System;

namespace ALPS.DTO
{
	public abstract class Company
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string PrimaryContact { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string Phone { get; set; }
		public string Mobile { get; set; }
		public string Fax { get; set; }
		public string Email { get; set; }
		public string Notes { get; set; }
		public bool Active { get; set; }
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }

		public byte[] Version { get; set; }
	}
}
