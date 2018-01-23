using System;
using System.ComponentModel.DataAnnotations;
using ALPS.API.Interfaces;

namespace ALPS.API.Entities
{
    public class Pricing : IVersionedEntity
    {
        public long Id { get; set; }
        public decimal Price { get; set; }
		public string Notes { get; set; }
		public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        // Navigation properties
        public virtual Repossessor Repossessor { get; set; }
        public virtual Lienholder Lienholder { get; set; }
        public virtual Service Service { get; set; }
    }
}