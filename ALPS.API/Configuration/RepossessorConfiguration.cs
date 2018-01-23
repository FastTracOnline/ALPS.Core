using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALPS.API.Entities;

namespace ALPS.API.Configuration
{
    public class RepossessorConfiguration : EntityTypeConfiguration<Repossessor>
    {
        public RepossessorConfiguration()
        {
            //HasMany(s => s.Agents)
            //   .WithRequired(p => p.Repossessor);

            //HasMany(s => s.ExpenseTypes)
            //   .WithRequired(p => p.Repossessor);

            //HasMany(s => s.Lienholders)
            //   .WithRequired(p => p.Repossessor);

            //HasMany(s => s.Locations)
            //   .WithRequired(p => p.Repossessor);

            //HasMany(s => s.Orders)
            //   .WithRequired(p => p.Repossessor);

            //HasMany(s => s.Services)
            //   .WithRequired(p => p.Repossessor);

            //HasMany(s => s.Vendors)
            //   .WithRequired(p => p.Repossessor);
        }
    }
}
