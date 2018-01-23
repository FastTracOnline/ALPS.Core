using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALPS.API.Interfaces;

namespace ALPS.API.Entities
{
    public class InvoiceDetail : IVersionedEntity
    {
		[Key]
		public int Id { get; set; }

		[Timestamp]
		public byte[] Version { get; set; }

		// Navigation Properties
		public Invoice Invoice { get; set; }
	}
}
