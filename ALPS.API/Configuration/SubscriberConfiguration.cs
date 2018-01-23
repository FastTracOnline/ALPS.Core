using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALPS.API.Entities;

namespace ALPS.API.Configuration
{
    public class SubscriberConfiguration : EntityTypeConfiguration<Subscriber>
    {
        public SubscriberConfiguration()
        {
        }
    }
}
