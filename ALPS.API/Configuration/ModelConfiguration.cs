using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALPS.API.Entities;

namespace ALPS.API.Configuration
{
    public class ModelConfiguration : EntityTypeConfiguration<Model>
    {
        public ModelConfiguration()
        {
            // Model has 1 Manufacturer, Manufacturer has many Model records
            //HasRequired(s => s.Make)
            //   .WithMany(p => p.Models);

            // Model has many Orders, each Order is for one Vehicle
            //HasMany(s => s.Orders)
            //   .WithOptional(p => p.Model);
        }
    }
}
