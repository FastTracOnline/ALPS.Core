using System;
using System.ComponentModel.DataAnnotations;
using ALPS.API.Interfaces;

namespace ALPS.API.Entities
{
    public class ServiceUsed : IVersionedEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ServiceType { get; set; }
        public decimal BasePrice { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        // Navigation properties
        public virtual Order Order { get; set; }
        public virtual Service Service { get; set; }
    }
}