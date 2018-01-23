using ALPS.API.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALPS.API.Entities
{
    [Table("Locations")]
    public class Location : IVersionedEntity
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Notes { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        // Navigation properties
        [ForeignKey("Subscriber")]
        public long SubscriberId { get; set; }
        [Required]
        public Subscriber Subscriber { get; set; }
    }
}