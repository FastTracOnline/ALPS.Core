using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ALPS.Common;

namespace ALPS.MVC.ViewModels
{
    public class Order
    {
		public Order()
		{
			Lienholder = new Lienholder();
			Debtor = new Contact();
			Vehicle = new Vehicle();
			AssignedTo = new Agent();
			Contacts = new HashSet<Contact>();
			BillToClient = new Lienholder();
		}

		public long Id { get; set; }
		[Display(Name = "Order #")]
		public string OrderNumber { get; set; }
		[Display(Name = "Client Ref #")]
		public string ClientRefNo { get; set; }
		[Display(Name = "Order Type")]
		public OrderType OrderType { get; set; }
		[Display(Name = "Order Status")]
		public OrderStatus OrderStatus { get; set; }
		[DataType(DataType.DateTime)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime Received { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime? Repossessed { get; set; }
		[Display(Name = "Collateral Released")]
		[DataType(DataType.DateTime)]
		public DateTime? VehicleReleased { get; set; }
		[Display(Name = "Has Property?")]
		public bool HasProperty { get; set; }
		[Display(Name = "Property Released")]
		[DataType(DataType.DateTime)]
		public DateTime? PropertyReleased { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime? Billed { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime? Paid { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime? Closed { get; set; }
		[Display(Name = "Reason for Close")]
		public CloseReason? CloseReason { get; set; }

		// Loan Information
		[Display(Name = "Due Date")]
		public DateTime? DueDate { get; set; }
		[Display(Name = "Past Due")]
		public DateTime? PastDue { get; set; }
		[Display(Name = "Loan Date")]
		public DateTime? LoanDate { get; set; }
		[Display(Name = "Last Pmt Recvd")]
		public DateTime? LastPayment { get; set; }
		[Display(Name = "Loan Amount")]
		public decimal? Amt_Loan { get; set; }
		[Display(Name = "Loan Balance")]
		public decimal? Amt_Balance { get; set; }
		[Display(Name = "Payment Amount")]
		public decimal? Amt_Payment { get; set; }
		[Display(Name = "Amount Due")]
		public decimal? Amt_Due { get; set; }

		// Repossession Information
		[DataType(DataType.MultilineText)]
		public string Remarks { get; set; }
		[DataType(DataType.MultilineText)]
		public string Property { get; set; }

		//Billing Information
		[Display(Name = "Free Days")]
		public int PropertyDaysFree { get; set; }
		[Display(Name = "Initial Fee")]
		[DataType(DataType.Currency)]
		public decimal PropertyInitialFee { get; set; }
		[Display(Name = "Daily Fee")]
		[DataType(DataType.Currency)]
		public decimal PropertyDailyFee { get; set; }
		[Display(Name = "Free Days")]
		public int VehicleDaysFree { get; set; }
		[Display(Name = "Initial Fee")]
		[DataType(DataType.Currency)]
		public decimal VehicleInitialFee { get; set; }
		[Display(Name = "Daily Fee")]
		[DataType(DataType.Currency)]
		public decimal VehicleDailyFee { get; set; }

		[DataType(DataType.MultilineText)]
		public string Notes { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        // Navigation properties
		public long SubscriberId { get; set; }
        public virtual Subscriber Subscriber { get; set; }

		[Display(Name = "Client")]
		public long LienholderId { get; set; }
        public virtual Lienholder Lienholder { get; set; }

		[Display(Name = "Debtor")]
		public long DebtorId { get; set; }
		public virtual Contact Debtor { get; set; }

		// Vehicle Information
		public long VehicleId { get; set; }
		public virtual Vehicle Vehicle { get; set; }

		[Display(Name = "Assigned To")]
		public long AgentId { get; set; }
		public virtual Agent AssignedTo { get; set; }

		public virtual ICollection<Contact> Contacts { get; set; }

		[Display(Name = "Bill To (if different)")]
		public long BillToId { get; set; }
		public virtual Lienholder BillToClient { get; set; }

		//public virtual ConditionReport ConditionReport { get; set; }
		//public virtual ICollection<Photos> Photos { get; set; }

		//[ForeignKey("Location_Id")]
		//public virtual Location Location { get; set; }

		//public virtual ICollection<Assignment> Assignments { get; set; }
	}
}