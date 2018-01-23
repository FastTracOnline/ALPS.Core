using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ALPS.MVC.ViewModels
{
	public abstract class Company
	{
		public long Id { get; set; }
		[Display(Name = "Company Name")]
		[DataType(DataType.Text)]
		public string Name { get; set; }
		[Display(Name = "Primary Contact")]
		[DataType(DataType.Text)]
		public string PrimaryContact { get; set; }
		[Display(Name = "Address")]
		[DataType(DataType.Text)]
		public string Address { get; set; }
		[Display(Name = "City")]
		[DataType(DataType.Text)]
		public string City { get; set; }
		[Display(Name = "State")]
		[DataType(DataType.Text)]
		public string State { get; set; }
		[Display(Name = "Zip")]
		[DataType(DataType.PostalCode)]
		public string Zip { get; set; }
		[Display(Name = "Phone")]
		[DataType(DataType.PhoneNumber)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:(###) ###-####}")]
		public string Phone { get; set; }
		[Display(Name = "Mobile")]
		[DataType(DataType.PhoneNumber)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:(###) ###-####}")]
		public string Mobile { get; set; }
		[Display(Name = "Fax")]
		[DataType(DataType.PhoneNumber)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:(###) ###-####}")]
		public string Fax { get; set; }
		[Display(Name = "Email Address")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Display(Name = "Notes")]
		[DataType(DataType.MultilineText)]
		public string Notes { get; set; }
		public bool Active { get; set; }
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }

		public byte[] Version { get; set; }
	}
}
