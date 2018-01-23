using System;
using ALPS.Common;
using System.ComponentModel.DataAnnotations;

namespace ALPS.DTO
{
	public class Service
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public ServiceType ServiceType { get; set; }
		public FeeType FeeType { get; set; }
        public decimal BasePrice { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public byte[] Version { get; set; }
        public long SubscriberId { get; set; }
		public Subscriber Subscriber { get; set; }
    }
}