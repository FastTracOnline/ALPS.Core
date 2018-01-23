using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALPS.API.Interfaces;

namespace ALPS.API.Entities
{
    public class PaymentDetail : IVersionedEntity
    {
		[Key]
		public int Id { get; set; }
		public decimal Amount { get; set; }
		public string Notes { get; set; }

		[Timestamp]
		public byte[] Version { get; set; }

		// Navigation Properties
		public Payment Payment { get; set; }
		public Invoice Invoice { get; set; }
	}
}
