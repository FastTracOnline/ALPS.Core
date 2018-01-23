using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALPS.API.Interfaces;

namespace ALPS.API.Entities
{
	public enum PaymentStatus
	{
		Unknown = 0,
		Received = 1,
		Applied = 2,
		Completed = 3,
		Void = 9
	}

	public class Payment : IVersionedEntity
    {
		[Key]
		public int Id { get; set; }
		public DateTime Received { get; set; }
		public DateTime? PaymentDate { get; set; }
		public decimal Amount { get; set; }
		public int Status { get; set; }                     // 1 = Received; 2 = Applied; 3 = Completed; 9 = Void
		public string Notes { get; set; }

		[Timestamp]
		public byte[] Version { get; set; }

		// Navigation Properties
		public Lienholder Lienholder { get; set; }
		public ICollection<PaymentDetail> PaymentDetails { get; set; }
	}
}
