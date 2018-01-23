using System;
using ALPS.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ALPS.API.Interfaces;

namespace ALPS.API.Entities
{
    [Table("Models")]
    public class Model : IVersionedEntity
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public VehicleType VehicleType { get; set; }
        public string Notes { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        // Navigation properties
        [ForeignKey("Make")]
        public int Make_Id { get; set; }
        public virtual Make Manufacturer { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}