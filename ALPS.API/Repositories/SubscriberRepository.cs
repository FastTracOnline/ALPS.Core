using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ALPS.API;
using ALPS.API.Entities;
using ALPS.API.Interfaces;

namespace ALPS.API.Repositories
{
    public class SubscriberRepository : EFRepository<Subscriber>, ISubscriberRepository
    {
		public SubscriberRepository(DbContext context) : base(context) { }

        public IQueryable<Subscriber> GetAll(long id)
        {
            if (id == 0)
                return DbSet;
            else
                return DbSet.Where(p => p.Id == id);
        }
    }
}
