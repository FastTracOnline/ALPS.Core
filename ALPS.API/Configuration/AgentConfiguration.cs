using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALPS.DAO.Entities;

namespace ALPS.DAO.Configuration
{
    public class AgentConfiguration : EntityTypeConfiguration<Agent>
    {
        public AgentConfiguration()
        {
            // Agent has 1 Repossessor, Repossessor has many Agent records
            //HasRequired(s => s.Repossessor)
            //   .WithMany(p => p.Agents);
        }
    }
}
