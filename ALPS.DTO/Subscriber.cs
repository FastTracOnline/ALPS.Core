using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ALPS.DTO
{
    public class Subscriber : Company
	{
        public Subscriber() 
        {
            //Agents = new HashSet<Agent>();
            //Lienholders = new HashSet<Lienholder>();
            //Locations = new HashSet<Location>();
            //Services = new HashSet<Service>();
            //Users = new HashSet<User>();
            //Vendors = new HashSet<Vendor>();
            //Orders = new HashSet<Order>();
        }

        public string Type { get; set; }
        public decimal Balance { get; set; }
        public string TenantName { get; set; }

        // Navigation properties
        //public virtual ICollection<Agent> Agents { get; set; }
        //public virtual ICollection<Lienholder> Lienholders { get; set; }
        //public ICollection<Location> Locations { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }
        //public virtual ICollection<Service> Services { get; set; }
        //public virtual ICollection<User> Users { get; set; }
        //public virtual ICollection<Vendor> Vendors { get; set; }
    }
}

