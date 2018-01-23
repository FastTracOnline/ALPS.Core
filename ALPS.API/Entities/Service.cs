using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ALPS.API.Interfaces;
using ALPS.Common;

namespace ALPS.API.Entities
{
	public class Service : IVersionedEntity
    {
		[Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
        public string Description { get; set; }
        public ServiceType ServiceType { get; set; }
		public FeeType FeeType { get; set; }
		[DataType(DataType.Currency)]
        public decimal BasePrice { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        // Navigation properties
        public long SubscriberId { get; set; }
        public virtual Subscriber Subscriber { get; set; }
    }
}