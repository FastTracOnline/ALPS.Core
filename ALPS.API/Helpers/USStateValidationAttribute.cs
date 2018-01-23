using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ALPS.API.Entities;

namespace ALPS.API.Helpers
{
    public class USStateValidationAttribute
    {
        public class ValidUSState : ValidationAttribute
        {
            private static string states = "|AL|AK|AS|AZ|AR|CA|CO|CT|DE|DC|FM|FL|GA|GU|HI|ID|IL|IN|IA|KS|KY|LA|ME|MH|MD|MA|MI|MN|MS|MO|MT|NE|NV|NH|NJ|NM|NY|NC|ND|MP|OH|OK|OR|PW|PA|PR|RI|SC|SD|TN|TX|UT|VT|VI|VA|WA|WV|WI|WY|";

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var model = (Address)validationContext.ObjectInstance;
                if ((String.IsNullOrEmpty(model.State)) || (model.State.Length == 2 && states.IndexOf(model.State) > 0))
                    return null;

                return new ValidationResult("Not a valid USPS State abbreviation");
            }
        }
    }
}
