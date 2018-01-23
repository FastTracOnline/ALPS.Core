using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ALPS.API.Interfaces;

namespace ALPS.API.Entities
{
    public class Assignment : IVersionedEntity
    {
        [Key]
        public int Id { get; set; }
        public int? PropertyDays { get; set; }
        public int? FreeStorageDays { get; set; }
        public decimal? CollateralOneTimeFee { get; set; }
        public decimal? CollateralDailyFee { get; set; }
        public decimal? PropertyOneTimeFee { get; set; }
        public decimal? PropertyDailyFee { get; set; }
        public string Notes { get; set; }
        public int AssignedBy { get; set; }
        public DateTime Assigned { get; set; }
        public int? AcceptedBy { get; set; }
        public DateTime? Accepted { get; set; }
        public int? CancelledBy { get; set; }
        public DateTime? Cancelled { get; set; }
        public int? CompletedBy { get; set; }
        public DateTime? Completed { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        // Navigation properties
        public virtual Lienholder Lienholder { get; set; }
		public virtual Repossessor Repossessor { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<ServiceUsed> ServicesUsed { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
