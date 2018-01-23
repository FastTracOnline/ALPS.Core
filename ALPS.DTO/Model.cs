using System;
using System.Collections.Generic;
using ALPS.Common;
using System.ComponentModel.DataAnnotations;

namespace ALPS.DTO
{
    public class Model
    {
        public int Id { get; set; }
        [Display(Name ="Model")]
        public string ModelName { get; set; }
        [Display(Name = "Vehicle Type")]
        public VehicleType VehicleType { get; set; }
        public string Notes { get; set; }
        public bool Active { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Updated { get; set; }
        public int Make_Id { get; set; }
        public Make Manufacturer { get; set; }

        public bool IsValid()
        {
            return true;
        }
    }
}