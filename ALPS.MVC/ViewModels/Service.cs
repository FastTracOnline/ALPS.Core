using System;
using ALPS.Common;
using System.ComponentModel.DataAnnotations;

namespace ALPS.MVC.ViewModels
{
	public class Service
    {
        public long Id { get; set; }
        public string Description { get; set; }
        [Display(Name ="Type of Service")]
        public ServiceType ServiceType { get; set; }
		[Display(Name = "Fee Type")]
		public FeeType FeeType { get; set; }
		[Display(Name ="Base Price")]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal BasePrice { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public byte[] Version { get; set; }
        public long SubscriberId { get; set; }
		public Subscriber Subscriber { get; set; }
    }
}