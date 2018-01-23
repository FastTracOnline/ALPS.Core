using ALPS.Common;
using System;

namespace ALPS.DTO
{
	public class Expense
    {
		public long Id { get; set; }
        public DateTime ExpenseDate { get; set; }
		public ExpenseCategory ExpenseCategory { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
		public bool BillClient { get; set; }
        public DateTime DatePaid { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

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