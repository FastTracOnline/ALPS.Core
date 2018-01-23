using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALPS.API.Entities;

namespace ALPS.API.Configuration
{
    public class ServiceConfiguration : EntityTypeConfiguration<Service>
    {
        public ServiceConfiguration()
        {
            // Service has 1 Repossessor, Repossessor has many Service records
            //HasRequired(s => s.Repossessor)
            //   .WithMany(p => p.Services);
        }
    }
}
