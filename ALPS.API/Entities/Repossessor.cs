using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ALPS.API.Interfaces;

namespace ALPS.API.Entities
{
	[Table("Repossessors")]
	public class Repossessor : Company
	{
		public string TenantName { get; set; }
		public float Balance { get; set; }

        // Navigation properties
        public virtual ICollection<Agent> Agents { get; set; }
        //public ICollection<ExpenseType> ExpenseTypes { get; set; }
        public virtual ICollection<Lienholder> Lienholders { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Vendor> Vendors { get; set; }
    }
}
