using System;

namespace ALPS.DTO
{
	public class CompanyList
	{
		public int Id { get; set; }
		public string CompanyName { get; set; }
        public string CompanyType { get; set; }
        public string PrimaryContact { get; set; }
		public string PrimaryPhone { get; set; }
		public string PrimaryEmail { get; set; }
		public bool Active { get; set; }
		public DateTime Created { get; set; }
	}
}
