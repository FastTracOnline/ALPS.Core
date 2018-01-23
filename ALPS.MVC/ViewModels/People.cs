using System;
using System.ComponentModel.DataAnnotations;

namespace ALPS.MVC.ViewModels
{
	public abstract class People
	{
		public long Id { get; set; }
		[Display(Name = "First Name")]
		[DataType(DataType.Text)]
		public string FirstName { get; set; }
		[Display(Name = "Last Name")]
		[DataType(DataType.Text)]
		public string LastName { get; set; }
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
		[Display(Name = "Primary Phone")]
		[DataType(DataType.PhoneNumber)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:(###) ###-####}")]
		public string Phone { get; set; }
		[Display(Name = "Mobile Phone")]
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
		[DataType(DataType.MultilineText)]
		public string Notes { get; set; }
		public bool Active { get; set; }
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }

		public byte[] Version { get; set; }
	}
}
