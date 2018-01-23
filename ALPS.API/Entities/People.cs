using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ALPS.API.Interfaces;

namespace ALPS.API.Entities
{
    public abstract class People : IVersionedEntity
    {
		[Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
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

		[Timestamp]
		public byte[] Version { get; set; }
	}
}
