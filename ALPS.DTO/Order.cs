using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ALPS.Common;

namespace ALPS.DTO
{
    public class Order
    {
		public long Id { get; set; }
		public string OrderNumber { get; set; }
        public string ClientRefNo { get; set; }
		public OrderType OrderType { get; set; }
		public OrderStatus OrderStatus { get; set; }
		public DateTime Received { get; set; }
        public DateTime? Repossessed { get; set; }
		public DateTime? VehicleReleased { get; set; }
		public bool HasProperty { get; set; }
		public DateTime? PropertyReleased { get; set; }
		public DateTime? Billed { get; set; }
		public DateTime? Paid { get; set; }
		public DateTime? Closed { get; set; }
		public CloseReason? CloseReason { get; set; }

		// Loan Information
		public DateTime? DueDate { get; set; }
        public DateTime? PastDue { get; set; }
        public DateTime? LoanDate { get; set; }
        public DateTime? LastPayment { get; set; }
        public decimal? Amt_Loan { get; set; }
        public decimal? Amt_Balance { get; set; }
        public decimal? Amt_Payment { get; set; }
        public decimal? Amt_Due { get; set; }

        // Repossession Information
        public string Remarks { get; set; }
        public string Property { get; set; }

		//Billing Information
		public int PropertyDaysFree { get; set; }
		[DataType(DataType.Currency)]
		public decimal PropertyInitialFee { get; set; }
		[DataType(DataType.Currency)]
		public decimal PropertyDailyFee { get; set; }
		public int VehicleDaysFree { get; set; }
		[DataType(DataType.Currency)]
		public decimal VehicleInitialFee { get; set; }
		[DataType(DataType.Currency)]
		public decimal VehicleDailyFee { get; set; }

		public string Notes { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        // Navigation properties
		public long SubscriberId { get; set; }
        public virtual Subscriber Subscriber { get; set; }

		public long LienholderId { get; set; }
        public virtual Lienholder Lienholder { get; set; }

		public long DebtorId { get; set; }
		public virtual Contact Debtor { get; set; }

		// Vehicle Information
		public long VehicleId { get; set; }
		public virtual Vehicle Vehicle { get; set; }

		public long AgentId { get; set; }
		public virtual Agent AssignedTo { get; set; }

		public virtual ICollection<Contact> Contacts { get; set; }

		public long BillToId { get; set; }
		public virtual Lienholder BillToClient { get; set; }

		//public virtual ConditionReport ConditionReport { get; set; }
		//public virtual ICollection<Photos> Photos { get; set; }

		//[ForeignKey("Location_Id")]
		//public virtual Location Location { get; set; }

		//public virtual ICollection<Assignment> Assignments { get; set; }
	}
}