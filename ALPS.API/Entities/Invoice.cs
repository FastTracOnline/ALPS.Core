using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ALPS.API.Interfaces;

namespace ALPS.API.Entities
{
	public enum InvoiceStatus
	{
		Unknown = 0,
		New = 1,
		Sent = 2,
		Paid = 3,
		WriteOff = 8,
		Void = 9
	}

	public class Invoice : IVersionedEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime? InvoiceSent { get; set; }
        public int Status { get; set; }                     // 1 = New; 2 = Sent; 3 = Paid; 8 = Write Off, 9 = Void
        public string Notes { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        // Navigation Properties
        public Order Order { get; set; }
		public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
