using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ALPS.Common;
using static ALPS.API.Helpers.USStateValidationAttribute;

namespace ALPS.API.Entities
{
	public class Address
	{
		[Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        [Required]
		public AddressType AddressType { get; set; }
        [MaxLengthAttribute(40)]
        public string StreetAddress1 { get; set; }
        [MaxLengthAttribute(40)]
        public string StreetAddress2 { get; set; }
        [MaxLengthAttribute(20)]
        public string City { get; set; }
        [MaxLengthAttribute(2)]
        [ValidUSState()]
        public string State { get; set; }
        [MaxLengthAttribute(10)]
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$")]
        public string Zip { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
    }
}
