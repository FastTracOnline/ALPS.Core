using ALPS.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALPS.API.Entities
{
    [Table("Subscribers")]
    public class Subscriber : Company
    {
        public Subscriber()
        {
            Agents = new HashSet<Agent>();
            Lienholders = new HashSet<Lienholder>();
			Services = new HashSet<Service>();
			PoliceDepartments = new HashSet<PoliceDepartment>();
			Vendors = new HashSet<Vendor>();
			MakeModels = new HashSet<MakeModel>();
			Debtors = new HashSet<Contact>();
			Contacts = new HashSet<Contact>();
			Employers = new HashSet<Employer>();
			Expenses = new HashSet<Expense>();
			Orders = new HashSet<Order>();
			Vehicles = new HashSet<Vehicle>();
		}

		public string Type { get; set; }
		public decimal Balance { get; set; }
        public string TenantName { get; set; }

        // Navigation properties
        public virtual ICollection<Agent> Agents { get; set; }
        public virtual ICollection<Lienholder> Lienholders { get; set; }
		public virtual ICollection<Service> Services { get; set; }
		public virtual ICollection<PoliceDepartment> PoliceDepartments { get; set; }
		public virtual ICollection<Vendor> Vendors { get; set; }
		public virtual ICollection<MakeModel> MakeModels { get; set; }
		public virtual ICollection<Contact> Debtors { get; set; }
		public virtual ICollection<Contact> Contacts { get; set; }
		public virtual ICollection<Employer> Employers { get; set; }
		public virtual ICollection<Expense> Expenses { get; set; }
		public virtual ICollection<Order> Orders { get; set; }
		public virtual ICollection<Vehicle> Vehicles { get; set; }
	}
}
