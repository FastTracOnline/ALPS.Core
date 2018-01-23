using System;
using System.ComponentModel.DataAnnotations;

namespace ALPS.DTO
{
	public class RepossessorList
	{
		public int Id { get; set; }
		public string CompanyName { get; set; }
		public string PrimaryContact { get; set; }
		public string PrimaryPhone { get; set; }
		public string PrimaryEmail { get; set; }
		public bool Active { get; set; }
        public DateTime Created { get; set; }
        public string TenantName { get; set; }
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public decimal Balance { get; set; }
    }
}
