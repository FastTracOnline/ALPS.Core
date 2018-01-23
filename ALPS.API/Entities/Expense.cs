using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ALPS.API.Interfaces;
using ALPS.Common;

namespace ALPS.API.Entities
{
	[Table("Expenses")]
	public class Expense : IVersionedEntity
    {
		[Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
        public DateTime ExpenseDate { get; set; }
		public ExpenseCategory ExpenseCategory { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
		public bool BillClient { get; set; }
        public DateTime DatePaid { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        // Navigation properties
		public long SubscriberId { get; set; }
        public virtual Subscriber Subscriber{ get; set; }

		public long VendorId { get; set; }
		public virtual Vendor Vendor { get; set; }

		public long OrderId { get; set; }
		public virtual Order Order { get; set; }
	}
}