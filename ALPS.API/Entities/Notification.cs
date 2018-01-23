using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ALPS.API.Interfaces;

namespace ALPS.API.Entities
{
    public class Notification : IVersionedEntity
    {
        [Key]
        public int Id { get; set; }
        public int FromTo { get; set; }                     // 1 = LH to Repo;  2 = Repo to LH; 3 = Repo to Agent; 4 = Agent to Repo
        public DateTime NotificationDate { get; set; } 
        public int NotificationType { get; set; }           // 1 = Status Update;  2 = Condition Report Ready;  3 = Invoice Ready;  4 = Order Updated
        public string NotificationText { get; set; }
        public DateTime? Acknowledged { get; set; }
        public int? AcknowledgedBy { get; set; }
        public int SentBy { get; set; }                 
        public DateTime Updated { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        // Navigation properties
        public virtual Assignment Assignment { get; set; }
    }
}
