using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ALPS.DTO
{
    public class Make
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Notes { get; set; }
        public bool Active { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Updated { get; set; }

        public ICollection<Model> Models { get; set; }

        public bool IsValid()
        {
            return true;
        }
    }
}