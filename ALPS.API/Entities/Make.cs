using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ALPS.API.Interfaces;

namespace ALPS.API.Entities
{
    [Table("Makes")]
    public class Make : IVersionedEntity
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Notes { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}