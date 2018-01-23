using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ALPS.DTO
{
	public class Repossessor : Company
	{
        [Display(Name="Tenant")]
        public string TenantName { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
		public float Balance { get; set; }

        // Children
        public virtual ICollection<Agent> Agents { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Lienholder> Lienholders { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Vendor> Vendors { get; set; }

        public new bool IsValid()
        {
            var result = !(String.IsNullOrWhiteSpace(CompanyName) ||
                String.IsNullOrWhiteSpace(PrimaryContact) ||
                String.IsNullOrWhiteSpace(TenantName) ||
                Balance < 0);

            return result;
        }
    }
}
